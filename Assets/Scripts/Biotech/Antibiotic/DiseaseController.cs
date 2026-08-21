using UnityEngine;

public class DiseaseController : MonoBehaviour
{
    private Player player;
    private bool isAfected=false;
    [SerializeField]private GameObject diseaseIndicator;
    [SerializeField] private UiSlider healthBar;
    [SerializeField][Range(0f,100f)] private float percentageToDisease=0.1f;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    public void OnEat()
    {
        var value = Random.Range(0f,100f);
        if (value<=percentageToDisease)
        {
            ActiveDisease();
        }
    }

    private void ActiveDisease()
    {
        if (isAfected) return;
        isAfected=true;
        diseaseIndicator.SetActive(isAfected);
        PlayerStatsManager.speedMultipliyer*=0.9f;
        PlayerStatsManager.healthMultipliyer*=0.9f;
        var playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement==null)
        {
            Debug.LogError("Não tem PlayerMovement no Player");
            return;
        }
        var playerHealthController = player.GetComponent<HealthController>();
        if (playerHealthController==null)
        {
            Debug.LogError("Não tem HealthController no Player");
            return;
        }
        playerHealthController.UpdateStats();
        healthBar.GrowBar(0.9f,true);
        playerMovement.UpdateSpeed();
    }

    public void DesactiveDisease()
    {
        if (!isAfected) return;
        isAfected=false;
        diseaseIndicator.SetActive(isAfected);
        PlayerStatsManager.speedMultipliyer*=1.1f;
        PlayerStatsManager.healthMultipliyer*=1.1f;
        var playerMovement = player.GetComponent<PlayerMovement>();
        if (playerMovement==null)
        {
            Debug.LogError("Não tem PlayerMovement no Player");
            return;
        }
        var playerHealthController = player.GetComponent<HealthController>();
        if (playerHealthController==null)
        {
            Debug.LogError("Não tem HealthController no Player");
            return;
        }
        playerHealthController.UpdateStats();
        healthBar.GrowBar(1.1f,true);
        playerMovement.UpdateSpeed();
    }
}
