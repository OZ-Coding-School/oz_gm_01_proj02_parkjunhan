using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region field
    public List<ItemDataSO> items;

    [SerializeField] Transform slotParent;
    [SerializeField] InventorySlot[] slots;
    #endregion

    void Awake()
    {
        slots = slotParent.GetComponentsInChildren<InventorySlot>();

        FreshSlot();
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