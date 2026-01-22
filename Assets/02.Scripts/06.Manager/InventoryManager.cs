using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    #region field
    public static InventoryManager Instance { get; private set; }

    [Header("인벤토리")]
    Inventory inventory;
    [SerializeField] Equipment equipment;
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

        inventory = Inventory.Instance;

        equipment = GameObject.Find("GameObject/Canvas/UI/PlayerUI/EquipeUI")
            .GetComponent<Equipment>();
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

        if (item.counter <= 0) inventory.RemoveItem(item);
    }

    private void UseStatusRecovery(Slot slot)
    {

    }

    private void UseExpendables(Slot slot)
    {

    }

    private void UseEquip(Slot slot)
    {
        equipment.ClickedEquip(slot);
    }

    //플레이어 인벤토리
    public void OnInventoryClicked(Slot slot, PointerEventData eventData)
    {
        if (slot.Item == null) return;

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                {
                    switch (slot.Item.itemType)
                    {
                        case ItemType.LiquidMedicine:
                            {
                                UseLiquidMedicine(slot);
                            }
                            break;
                        case ItemType.StatusRecovery:
                            {
                                UseStatusRecovery(slot);
                            }
                            break;
                        case ItemType.Expendables:
                            {
                                UseExpendables(slot);
                            }
                            break;
                        case ItemType.Equipment:
                            {
                                UseEquip(slot);
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

    //플레이어 장비창
    public void OnEquipmentClicked(Slot slot, PointerEventData eventData)
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
    public void OnShopClicked(Slot slot, PointerEventData eventData)
    {
        if (slot.Item == null) return;

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                {
                    //아이템 구매
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