
using System.Collections;
using Unity.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private float health;
    [SerializeField] float initialMaxHealth=100;
    private float maxHealth=100;
    [SerializeField] private UiSlider healthBar;
    [SerializeField] private GameObject resetUi;

    private Animator anim;
    private bool blinking;
    [SerializeField] private float blinkingTime=1.5f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        maxHealth=initialMaxHealth*PlayerStatsManager.healthMultipliyer;
        health=maxHealth;
    }

    public void Damage(int amount)
    {
        if (blinking) 
            return;
            
        health-=amount;
        if (health>maxHealth)
        {
            health=maxHealth;
        }else if (health<=0)
        {
            health=0;
            Die();
        }
        anim.SetTrigger("damage");
        StartCoroutine(BlinkingCoroutine());
        healthBar.SetFill(health,maxHealth);
        SendMessage("OnDamage",SendMessageOptions.DontRequireReceiver);
    }

    private void Die()
    {
        resetUi.SetActive(true);
        //Temporário destruir
        Destroy(gameObject);
    }

    private IEnumerator BlinkingCoroutine()
    {
        blinking=true;
        anim.SetBool("blinking",blinking);
        yield return new WaitForSeconds(blinkingTime);
        blinking=false;
        anim.SetBool("blinking",blinking);
        
    }
    public void UpdateStats()
    {
        maxHealth=initialMaxHealth*PlayerStatsManager.healthMultipliyer;
        if (health>maxHealth)
            health=maxHealth;
    }

    public void AddHealth(float value)
    {
        if (health+value>maxHealth)
        {
            health=maxHealth;
        }
        else
        {
            health+=value;
        }
        healthBar.SetFill(health,maxHealth);
    }

}
