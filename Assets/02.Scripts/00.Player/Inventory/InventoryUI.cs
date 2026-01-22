using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region field
    [SerializeField] Transform slotParent;
    [SerializeField] InventorySlot[] slots;

    List<ItemDataSO> items;

    [Header("인벤토리 UI")]
    [SerializeField] public GameObject inventoryUI;
    #endregion

    void Awake()
    {
        Setting();
        FreshSlot();
    }
    void Update()
    {
        
    }

    #region method
    public void Setting()
    {
        slotParent = transform.Find("Scroll View/Viewport/Content");

        slots = slotParent.GetComponentsInChildren<InventorySlot>();

        inventoryUI = gameObject;

        items = Inventory.Instance.items;
    }

    public void FreshSlot()
    {
        if (items == null) return;

        int i = 0;
        for (; i < items.Count && i < slots.Length; i++)
        {
            slots[i].Item = items[i];
        }

        for (; i < slots.Length; i++)
        {
            slots[i].Item = null;
        }
    }
    #endregion
}