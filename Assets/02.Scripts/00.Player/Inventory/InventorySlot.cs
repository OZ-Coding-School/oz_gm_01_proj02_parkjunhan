using UnityEngine.EventSystems;

public class InventorySlot : Slot, IPointerClickHandler
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Update()
    {
        base.Update();
    }

    #region method
    public void OnPointerClick(PointerEventData eventData)
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnInventoryClicked(this, eventData);
        }
    }
    #endregion
}
