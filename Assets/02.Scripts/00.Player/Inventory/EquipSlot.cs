using UnityEngine.EventSystems;

public class EquipSlot : Slot, IPointerClickHandler
{
    public EquipSlotType slotType;

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (EquipmentManager.Instance != null)
        {
            EquipmentManager.Instance.OnEquipmentClicked(this, eventData);
        }
    }
}
