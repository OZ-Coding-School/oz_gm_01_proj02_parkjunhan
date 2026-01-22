using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    #region field
    [Header("인벤토리")]
    Inventory inventory;

    [Header("아이템 리스트")]
    [SerializeField] ItemDataSO[] itemList = new ItemDataSO[14];
    [SerializeField] Transform slotParent;
    [SerializeField] ShopSlot[] shopSlots;
    #endregion

    void Awake()
    {
        inventory = Inventory.Instance;

        slotParent = GameObject.Find("GameObject/Canvas/UI/ShopUI/Background/Scroll View/Viewport")
        .transform.Find("Content");
        shopSlots = slotParent.GetComponentsInChildren<ShopSlot>();

        FreshSlot();
    }

    void Update()
    {
        
    }

    #region method
    void FreshSlot()
    {
        if (itemList == null) return;

        int i = 0;
        for (; i < itemList.Length && i < shopSlots.Length; i++)
        {
            shopSlots[i].Item = itemList[i];
        }

        for (; i < shopSlots.Length; i++)
        {
            shopSlots[i] = null;
        }
    }
    #endregion
}