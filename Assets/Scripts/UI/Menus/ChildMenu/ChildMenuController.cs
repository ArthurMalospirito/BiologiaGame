
using UnityEngine;

public class ChildMenuController : MonoBehaviour
{
    [SerializeField] private ChildMenu childMenu;


    public void SetChild(GeneticController child)
    {
        childMenu.child=child;
    }

    public void OpenChildMenu()
    {
        childMenu.gameObject.SetActive(true);
    }
    public void CloseChildMenu()
    {
        childMenu.gameObject.SetActive(false);
    }
}