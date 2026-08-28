using UnityEngine;
using UnityEngine.InputSystem;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject TabMenu;
    private bool tabMenuActive=false;

    public void Awake()
    {
        TabMenu.SetActive(tabMenuActive);
    }

    public void OnTab(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            SwitchTabMenu();
        }
    }
    public void SwitchTabMenu()
    {
            tabMenuActive= tabMenuActive ? false : true;
            gameManager.SetPause(tabMenuActive);
            TabMenu.SetActive(tabMenuActive);
    }

}
