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
        slotParent = GameObject.Find("GameObject/Canvas/UI/PlayerUI/InventoryUI/Scroll View/Viewport")
            .transform.Find("Content");

        slots = slotParent.GetComponentsInChildren<InventorySlot>();

        inventoryUI = GameObject.Find("GameObject/Canvas/UI/PlayerUI")
            .transform.Find("InventoryUI").gameObject;

        items = Inventory.Instance.items;
    }

    public void FreshSlot()
    {
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