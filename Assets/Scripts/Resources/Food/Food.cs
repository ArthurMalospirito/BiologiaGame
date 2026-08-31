using System.Collections;
using Enums.EnumFoodType;
using UnityEngine;


public class Food: MonoBehaviour
{
    [SerializeField] private float linearDamping=5;

    private Rigidbody2D rb;
    private Collider2D coll;
    

    [SerializeField] private float foodAmount;
    [SerializeField] private float waterAmount;
    [SerializeField] private FoodTypes foodType;

    private string targetTag = "Player";

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag(targetTag)) return;
    
        ResourceController resourceController = collision.transform.GetComponent<ResourceController>();

        if (resourceController.CanEatType!=foodType) {
            if (DialogController.TryTrigger(Enums.DialogueTrigger.DialogTrigger.FirstCantEat))
                DarwinMenuController.Instance.OpenMenu(Enums.DialogueTrigger.DialogTrigger.FirstCantEat);
            return;
        }

        resourceController.AddFood(foodAmount);
        resourceController.AddWater(waterAmount);
        SendMessageUpwards("OnEat",SendMessageOptions.DontRequireReceiver);
        Destroy(gameObject);
    }

    public void AddForce(Vector2 pushForce)
    {
        rb.AddForce(pushForce);
    }

    public void MakeIntangible(float intangibleTime)
    {
        StartCoroutine(MakeIntangibleCoroutine(intangibleTime));
    }

    private IEnumerator MakeIntangibleCoroutine(float seconds)
    {
        coll.isTrigger=true;
        rb.linearDamping=linearDamping*0.25f;
        yield return new WaitForSeconds(seconds);
        rb.linearDamping=linearDamping;
        coll.isTrigger=false;
    }

}

