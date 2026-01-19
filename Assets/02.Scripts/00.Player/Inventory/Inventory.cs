using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region field
    public List<ItemDataSO> items;

    [SerializeField] Transform slotParent;
    [SerializeField] InventorySlot[] slots;

    [Header("인벤토리 UI")]
    [SerializeField] public GameObject inventoryUI;
    #endregion

    void Awake()
    {
        slotParent = GameObject.Find("GameObject/Canvas/InventoryUI/Scroll View/Viewport")
            .transform.Find("Content");

        slots = slotParent.GetComponentsInChildren<InventorySlot>();
        FreshSlot();

        inventoryUI = GameObject.Find("Canvas").transform.Find("InventoryUI").gameObject;
        //if (inventoryUI.gameObject.activeInHierarchy) inventoryUI.SetActive(false);
    }

    #region method
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

    public void AddItem(ItemDataSO item)
    {
        ItemDataSO duplication = null;

        if (item.recoveryHp > 0 && item.recoveryMp == 0)
        {
            duplication = items.Find(x => x.recoveryHp > 0);
        }
        else if (item.recoveryMp > 0 && item.recoveryHp == 0)
        {
            duplication = items.Find(x => x.recoveryMp > 0);
        }

        if (duplication != null)
        {
            duplication.counter++;
        }
        else if (duplication == null)
        {
            items.Add(item);
        }

        FreshSlot();
    }

    public void RemoveItem(ItemDataSO item)
    {
        if (item == null) return;

        items.Remove(item);
        FreshSlot();
    }
    #endregion
}