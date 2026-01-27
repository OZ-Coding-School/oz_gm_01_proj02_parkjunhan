using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    #region field
    public static InventoryManager Instance { get; private set; }

    //확인절차
    public bool needConfirm = false;
    public bool selectY = false;

    //선택된 아이템 정보
    public ItemType type = ItemType.None;
    public ItemGrade grade = ItemGrade.None;
    public TextMeshProUGUI selectItemName;
    public int price;
    public int sellPrice;
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
    }

    void Update()
    {
        
    }

    #region method
    private void UseLiquidMedicine(Slot slot)
    {
        ItemDataSO item = slot.Item;
        PlayerStatus player = PlayerStatus.Instance;

        bool canRecoverHp = item.recoveryHp > 0 && player.hp < player.maxHp;
        bool canRecoverMp = item.recoveryMp > 0 && player.mp < player.maxMp;

        if (!canRecoverHp && !canRecoverMp) return;

        if (canRecoverHp) player.ModifyHp(item.recoveryHp);
        if (canRecoverMp) player.ModifyMp(item.recoveryMp);

        item.counter--;

        if (item.counter <= 0) Inventory.Instance.RemoveItem(item);
    }

    private void UseStatusRecovery(Slot slot)
    {

    }

    private void UseExpendables(Slot slot)
    {

    }

    private void UseEquip(Slot slot)
    {
        Equipment.Instance.AddEquipment(slot);
    }

    //플레이어 인벤토리
    public void OnInventoryClicked(InventorySlot slot, PointerEventData eventData)
    {
        if (slot.Item == null) return;

        type = slot.Item.itemType;
        grade = slot.Item.itemGrade;
        selectItemName.text = slot.Item.itemName;
        price = slot.Item.price;
        sellPrice = slot.Item.sellPrice;

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                {
                    switch (slot.Item.itemType)
                    {
                        case ItemType.LiquidMedicine:
                            {
                                needConfirm = true;
                                if (selectY) UseLiquidMedicine(slot);
                                selectY = false;
                            }
                            break;
                        case ItemType.StatusRecovery:
                            {
                                needConfirm = true;
                                if (selectY) UseStatusRecovery(slot);
                                selectY = false;
                            }
                            break;
                        case ItemType.Expendables:
                            {
                                needConfirm = true;
                                if (selectY) UseExpendables(slot);
                                selectY = false;
                            }
                            break;
                        case ItemType.Equipment:
                            {
                                needConfirm = true;
                                if (selectY) UseEquip(slot);
                                selectY = false;
                            }
                            break;
                        case ItemType.Etc:
                            break;
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
    #endregion
}