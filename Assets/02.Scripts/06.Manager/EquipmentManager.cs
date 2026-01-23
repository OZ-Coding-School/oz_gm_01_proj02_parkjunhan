using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentManager : MonoBehaviour
{
    #region field
    public static EquipmentManager Instance { get; private set; }

    //확인절차
    public bool needRefresh = false;
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

    #region method
    //플레이어 장비창
    public void OnEquipmentClicked(EquipSlot slot, PointerEventData eventData)
    {
        if (slot.Item == null) return;

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                {
                    //slot의 아이탬 정보
                    type = slot.Item.itemType;
                    grade = slot.Item.itemGrade;
                    selectItemName.text = slot.Item.itemName;
                    price = slot.Item.price;
                    sellPrice = slot.Item.sellPrice;

                    //확인의사 UI 활성화
                    needConfirm = true;

                    if (selectY)
                    {
                        Equipment.Instance.RemoveEquipment(slot);
                    }

                    selectY = false;
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