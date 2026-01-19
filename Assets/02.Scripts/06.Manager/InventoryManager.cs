using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Inventory))]
[RequireComponent(typeof(EquipMent))]
public class InventoryManager : MonoBehaviour
{
    #region field
    public static InventoryManager Instance { get; private set; }

    [Header("인벤토리")]
    [SerializeField] Inventory inventory;
    [SerializeField] EquipMent equipMent;

    private bool useItem;
    #endregion

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        inventory = GetComponent<Inventory>();
        equipMent = GetComponent<EquipMent>();
    }

    void Update()
    {
        
    }

    #region method
    private void UseItem(Slot slot)
    {
        if (slot.Item.recoveryHp > 0 && slot.Item.recoveryMp == 0)
        {
            if (PlayerStatus.Instance.hp < PlayerStatus.Instance.maxHp) useItem = true;

            if (useItem)
            {
                PlayerStatus.Instance.ModifyHp(slot.Item.recoveryHp);
                slot.Item.counter--;
            }
        }
        else if (slot.Item.recoveryMp > 0 && slot.Item.recoveryHp == 0)
        {
            if (PlayerStatus.Instance.hp < PlayerStatus.Instance.maxHp) useItem = true;

            if (useItem)
            {
                PlayerStatus.Instance.ModifyMp(slot.Item.recoveryMp);
                slot.Item.counter--;
            }
        }
        
        if (slot.Item.counter <= 0) inventory.RemoveItem(slot.Item);
        useItem = false;
    }

    //플레이어 인벤토리
    public void OnInventoryClicked(InventorySlot slot, PointerEventData eventData)
    {
        if (slot.Item == null) return;

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                {
                    if (slot.Item.expendables)
                    {
                        UseItem(slot);
                    }
                    else if (slot.Item.equipment)
                    {
                        //장비 아이템 착용
                    }
                }
                break;
            case PointerEventData.InputButton.Right:
                {
                    //아이템 정보
                }
                break;
        }
    }

    //플레이어 장비창
    public void OnEquipmentClicked(EquipSlot slot, PointerEventData eventData)
    {
        if (slot.Item == null) return;

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                {
                    //장비 아이템 해제
                }
                break;
            case PointerEventData.InputButton.Right:
                {
                    //아이템 정보
                }
                break;
        }
    }

    //상점 인벤토리
    #endregion
}