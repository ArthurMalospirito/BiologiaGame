using UnityEngine;
using UnityEngine.EventSystems;

public class FlightButton : MonoBehaviour
{

    private PlayerFlight playerFlight;

    private void Awake()
    {
        playerFlight = GameObject.Find("Player").GetComponent<PlayerFlight>();
    }

    public void OnClick()
    {
        playerFlight.Fly();
    }
}
