

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class RightMenuController : MonoBehaviour
{
    private RightMenu rightMenu;
    [SerializeField] private RightMenu rightMenuPrefab;
    [SerializeField] private string targetTag="Bird";
    [SerializeField] private string dontCloseTag="Menu";
    [SerializeField] private int procreateCooldown=90;

    public void OnRightClick(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            var hit = VerifyHit();
            if (hit.collider==null) return;
            if (!hit.collider.gameObject.CompareTag(targetTag)) return;

            CreateRightMenu(hit);

        }
    }

    public void OnLeftClick(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            VerifyHit();
        }
    }

    private RaycastHit2D VerifyHit()
    {
        if (IsMouseOverTag(dontCloseTag)) return new RaycastHit2D();

        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 mouseWorld = Camera.main.ScreenToWorldPoint(mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorld,Vector2.zero);
        if (hit.collider == null || !hit.collider.gameObject.CompareTag(dontCloseTag))
        {
            CloseRightMenu();
        }
        return hit;
    }

    private void CreateRightMenu(RaycastHit2D hit)
    {
        if (rightMenu!=null)
        {
            Destroy(rightMenu.gameObject);
        } 
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        rightMenu = Instantiate(rightMenuPrefab,mousePosition,Quaternion.identity,gameObject.transform);

        GeneticController geneticController = hit.collider.GetComponent<GeneticController>();
        if (geneticController==null) {
            Debug.LogError("Não tem Genetic Controller no passaro");
            return;
        }
        rightMenu.targetGeneticController = geneticController;

        Creature creature = hit.collider.GetComponent<Creature>();
        if (creature==null)
        {
            Debug.LogError("Não tem Creature no passaro");
            return;
        }
        rightMenu.targetCreature = creature;

        Transform transform = hit.collider.transform;
        rightMenu.transformLocation = transform;

        rightMenu.Open();
        
    }

    public void CloseRightMenu()
    {
        if (rightMenu==null) return;
        Destroy(rightMenu.gameObject);
    }

    private bool IsMouseOverTag(string targetTag)
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current);
        pointerData.position = Mouse.current.position.ReadValue();

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData,results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.CompareTag(targetTag)) return true;
        }
        return false;
    }

    public void StartProcreateCooldown()
    {
        StartCoroutine(ProcreateCooldownCoroutine(procreateCooldown));
    }

    private IEnumerator ProcreateCooldownCoroutine(int procreateCooldown)
    {
        RightMenu.procreateCooldown = procreateCooldown;
        while (RightMenu.procreateCooldown>0)
        {
            yield return new WaitForSeconds(1);
            RightMenu.procreateCooldown-=1;
            if (rightMenu!=null)
                rightMenu.SetProcreateCooldown(RightMenu.procreateCooldown);
        }
        RightMenu.canProcreate=true;
    }

}