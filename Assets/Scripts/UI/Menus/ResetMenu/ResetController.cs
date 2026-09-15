
using TMPro;
using UnityEngine;

public class ResetController:MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text foodText;
    [SerializeField] private TMP_Text procreateText;
    [SerializeField] private TMP_Text biotechText;

    private void OnEnable()
    {
        DisplayStats();
    }

    private void DisplayStats()
    {
        //Colocar para pegar do timer;
        var time = "XX:XX";
        timeText.text = "Você sobreviveu por "+ "<size=40><b>"+ time +"</b></size>"+" Minutos";

        PlayerStatsManager.Instance.CountTotalFood();
        foodText.text = "Você comeu "+ "<size=40><b>"+ PlayerStatsManager.Instance.totalFood.ToString() +"</b></size>"+" comidas";

        procreateText.text = "Você teve "+ "<size=40><b>"+ PlayerStatsManager.Instance.totalProcreates.ToString() +"</b></size>"+" herdeiros";

        biotechText.text = "Você usou "+ "<size=40><b>"+ PlayerStatsManager.Instance.totalBiotechUses.ToString() +"</b></size>"+" biotecnologias";
    }
}