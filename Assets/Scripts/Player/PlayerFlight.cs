

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFlight : MonoBehaviour
{
    private bool canFly=true;
    private bool isFlying=false;
    private Coroutine _flightCorotuine;

    public float flightTime=5f;
    public float flightCooldown = 15f;
    [SerializeField] private float dragOnFlight=0.5f;
    public float flightSpeedMultipliyer=1.5f;

    [SerializeField] private UICooldown uICooldown;
    private Rigidbody2D rb; 
    private PlayerMovement playerMovement;
    private Animator anim;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerMovement=GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    public void OnFlight(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            Fly();
        }
    }

    public void Fly()
    {
        if (!canFly) return;
        if (isFlying) return;
        _flightCorotuine = StartCoroutine(FlightCoroutine(flightTime));
    }

    private void CancelFlight()
    {
        if (!isFlying) return;

        if (_flightCorotuine!=null) StopCoroutine(_flightCorotuine);
        rb.linearDamping=playerMovement.dragForce;
        playerMovement.Speed=playerMovement.normalSpeed*PlayerStatsManager.speedMultipliyer;
        isFlying=false;
        anim.SetBool("flying",isFlying);
        StartCoroutine(FlightCooldownCoroutine(flightCooldown));
    }

    private IEnumerator FlightCoroutine(float seconds)
    {
        canFly=false;
        isFlying=true;
        anim.SetBool("flying",isFlying);
        rb.linearDamping=dragOnFlight;
        playerMovement.Speed*=flightSpeedMultipliyer;
        yield return new WaitForSeconds(seconds);
        CancelFlight();
    }

    private IEnumerator FlightCooldownCoroutine(float seconds)
    {
        uICooldown.setInCooldown(seconds);
        yield return new WaitForSeconds(seconds);
        canFly=true;
    }
}