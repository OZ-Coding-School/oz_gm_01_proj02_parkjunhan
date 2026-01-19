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
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnEquipmentClicked(this, eventData);
        }
    }
}
