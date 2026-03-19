
using System.Collections;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth=100;
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

}
