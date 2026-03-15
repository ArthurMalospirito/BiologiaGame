
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int health;
    [SerializeField] private int maxHealth=100;
    [SerializeField] private UiSlider healthBar;
    [SerializeField] private GameObject resetUi;

    private void Start()
    {
        health=maxHealth;
    }

    public void Damage(int amount)
    {
        health-=amount;
        if (health>maxHealth)
        {
            health=maxHealth;
        }else if (health<=0)
        {
            health=0;
            Die();
        }
        healthBar.SetFill(health,maxHealth);
    }

    private void Die()
    {
        resetUi.SetActive(true);
        //Temporário destruir
        Destroy(gameObject);
    }

}
