using Enums.EnumMovementType;
using TMPro;
using UnityEngine;

public class MovementTypeController : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    private void OnEnable()
    {
        SetDropdown(PlayerMovement.currentMovementType);
    }

    public void OnDropdownChange()
    {
        int value = dropdown.value;
        PlayerMovement.currentMovementType = value==0 ? MovementType.SeekMouse : MovementType.EightDirection;
    }
    private void SetDropdown(MovementType movementType)
    {
        dropdown.value = movementType switch
        {
            MovementType.SeekMouse =>0,
            MovementType.EightDirection=>1,
            _=>0
        };
    }

}
