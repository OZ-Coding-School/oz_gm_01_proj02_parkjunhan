using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    #region field
    ItemDataSO selectItem;

    //
    string wColorCode = "";
    string sColorCode = "";

    [Header("상점 장비타입 UI")]
    [SerializeField] GameObject equipmentTypeUI;
    [SerializeField] Image wImage;
    [SerializeField] TextMeshProUGUI wName;
    [SerializeField] TextMeshProUGUI wGrade;
    [SerializeField] TextMeshProUGUI wAttackPowerNum;
    [SerializeField] TextMeshProUGUI wSkillPowerNum;
    [SerializeField] TextMeshProUGUI wDefenceNum;
    [SerializeField] TextMeshProUGUI wSpeedNum;
    [SerializeField] TextMeshProUGUI wInfo;
    [SerializeField] Image sImage;
    [SerializeField] TextMeshProUGUI sName;
    [SerializeField] TextMeshProUGUI sGrade;
    [SerializeField] TextMeshProUGUI sAttackPowerNum;
    [SerializeField] TextMeshProUGUI sSkillPowerNum;
    [SerializeField] TextMeshProUGUI sDefenceNum;
    [SerializeField] TextMeshProUGUI sSpeedNUm;
    [SerializeField] TextMeshProUGUI sInfo;

    [Header("상점 소모품타입 UI")]
    [SerializeField] GameObject expendablesUI;
    [SerializeField] Image expendImage;
    [SerializeField] TextMeshProUGUI expendName;
    [SerializeField] TextMeshProUGUI expendType;
    [SerializeField] TextMeshProUGUI expendGrade;
    [SerializeField] TextMeshProUGUI expendInfo;

    [Header("상점 상태회복타입 UI")]
    [SerializeField] GameObject statusRecoveryUI;
    [SerializeField] Image statusImage;
    [SerializeField] TextMeshProUGUI statusName;
    [SerializeField] TextMeshProUGUI statusType;
    [SerializeField] TextMeshProUGUI statusGrade;
    [SerializeField] TextMeshProUGUI statusInfo;

    [Header("상점 물약타입 UI")]
    [SerializeField] GameObject liquidMedicineUI;
    [SerializeField] Image liquidImage;
    [SerializeField] TextMeshProUGUI liquidName;
    [SerializeField] TextMeshProUGUI liquidType;
    [SerializeField] TextMeshProUGUI liquidGrade;
    [SerializeField] TextMeshProUGUI liquidInfo;

    //인벤토리

    //장비

    //UI체크용 변수
    Slot checkSlot = null;
    #endregion

    void Awake()
    {
        Setting();
    }

    void Update()
    {
        CheckUI();

        if (selectItem != null)
        {

        }
    }

    #region method
    public void Setting()
    {
        //상점 장비타입 UI
        equipmentTypeUI = GameObject.Find("UI/ShopUI/Background/ItemInfo/EquipmentType");
        wImage = GameObject.Find("Background/ItemInfo/EquipmentType/Wearing/ItemImage").GetComponent<Image>();
        wName = GameObject.Find("Background/ItemInfo/EquipmentType/Wearing/Layout/ItemName").GetComponent<TextMeshProUGUI>();
        wGrade = GameObject.Find("Background/ItemInfo/EquipmentType/Wearing/Layout/ItemGrade").GetComponent<TextMeshProUGUI>();
        wAttackPowerNum = GameObject.Find("Background/ItemInfo/EquipmentType/Wearing/Layout/StatusLayout/APNum")
            .GetComponent<TextMeshProUGUI>();
        wSkillPowerNum = GameObject.Find("Background/ItemInfo/EquipmentType/Wearing/Layout/StatusLayout/SPNum")
            .GetComponent<TextMeshProUGUI>();
        wDefenceNum = GameObject.Find("Background/ItemInfo/EquipmentType/Wearing/Layout/StatusLayout/DFNum")
            .GetComponent<TextMeshProUGUI>();
        wSpeedNum = GameObject.Find("Background/ItemInfo/EquipmentType/Wearing/Layout/StatusLayout/SNum")
            .GetComponent<TextMeshProUGUI>();
        wInfo = GameObject.Find("Background/ItemInfo/EquipmentType/Wearing/Info").GetComponent<TextMeshProUGUI>();

        sImage = GameObject.Find("Background/ItemInfo/EquipmentType/ShopItem/ItemImage").GetComponent<Image>();
        sName = GameObject.Find("Background/ItemInfo/EquipmentType/ShopItem/Layout/ItemName").GetComponent<TextMeshProUGUI>();
        sGrade = GameObject.Find("Background/ItemInfo/EquipmentType/ShopItem/Layout/ItemGrade").GetComponent<TextMeshProUGUI>();
        sAttackPowerNum = GameObject.Find("Background/ItemInfo/EquipmentType/ShopItem/Layout/StatusLayout/APNum")
            .GetComponent<TextMeshProUGUI>();
        sSkillPowerNum = GameObject.Find("Background/ItemInfo/EquipmentType/ShopItem/Layout/StatusLayout/SPNum")
            .GetComponent<TextMeshProUGUI>();
        sDefenceNum = GameObject.Find("Background/ItemInfo/EquipmentType/ShopItem/Layout/StatusLayout/DFNum")
            .GetComponent<TextMeshProUGUI>();
        sSpeedNUm = GameObject.Find("Background/ItemInfo/EquipmentType/ShopItem/Layout/StatusLayout/SNum")
            .GetComponent<TextMeshProUGUI>();
        sInfo = GameObject.Find("Background/ItemInfo/EquipmentType/ShopItem/Info").GetComponent<TextMeshProUGUI>();

        //상점 소모품타입 UI
        expendablesUI = GameObject.Find("UI/ShopUI/Background/ItemInfo/ExpendablesType");
        expendImage = GameObject.Find("Background/ItemInfo/ExpendablesType/ItemImage").GetComponent<Image>();
        expendName = GameObject.Find("Background/ItemInfo/ExpendablesType/Layout/ItemName").GetComponent<TextMeshProUGUI>();
        expendType = GameObject.Find("Background/ItemInfo/ExpendablesType/Layout/ItemType").GetComponent<TextMeshProUGUI>();
        expendGrade = GameObject.Find("Background/ItemInfo/ExpendablesType/Layout/ItemGrade").GetComponent<TextMeshProUGUI>();
        expendInfo = GameObject.Find("Background/ItemInfo/ExpendablesType/Layout/Info").GetComponent<TextMeshProUGUI>();

        //상점 상태회복타입 UI
        statusRecoveryUI = GameObject.Find("UI/ShopUI/Background/ItemInfo/StatusRecoveryType");
        statusImage = GameObject.Find("Background/ItemInfo/StatusRecoveryType/ItemImage").GetComponent<Image>();
        statusName = GameObject.Find("Background/ItemInfo/StatusRecoveryType/Layout/ItemName").GetComponent<TextMeshProUGUI>();
        statusType = GameObject.Find("Background/ItemInfo/StatusRecoveryType/Layout/ItemType").GetComponent<TextMeshProUGUI>();
        statusGrade = GameObject.Find("Background/ItemInfo/StatusRecoveryType/Layout/ItemGrade").GetComponent<TextMeshProUGUI>();
        statusInfo = GameObject.Find("Background/ItemInfo/StatusRecoveryType/Layout/Info").GetComponent<TextMeshProUGUI>();

        //상점 물약타입 UI
        liquidMedicineUI = GameObject.Find("UI/ShopUI/Background/ItemInfo/LiquidMedicineType");
        liquidImage = GameObject.Find("Background/ItemInfo/LiquidMedicineType/ItemImage").GetComponent<Image>();
        liquidName = GameObject.Find("Background/ItemInfo/LiquidMedicineType/Layout/ItemName").GetComponent<TextMeshProUGUI>();
        liquidType = GameObject.Find("Background/ItemInfo/LiquidMedicineType/Layout/ItemType").GetComponent<TextMeshProUGUI>();
        liquidGrade = GameObject.Find("Background/ItemInfo/LiquidMedicineType/Layout/ItemGrade").GetComponent<TextMeshProUGUI>();
        liquidInfo = GameObject.Find("Background/ItemInfo/LiquidMedicineType/Layout/Info").GetComponent<TextMeshProUGUI>();

        //인벤토리

        //장비
    }

    public void CheckUI()
    {
        if (checkSlot == null) return;

        if (ShopManager.Instance.shopSlot != null) checkSlot = ShopManager.Instance.shopSlot;

        switch (checkSlot)
        {
            case ShopSlot:
                {

                }
                break;
            case InventorySlot:
                {

                }
                break;
            case EquipSlot:
                {

                }
                break;
        }
    }

    public void ShopActiveUI()
    {
        switch (selectItem.itemType)
        {
            case ItemType.LiquidMedicine:
                {
                    SFontColor();

                    liquidImage.sprite = selectItem.itemImage;
                    liquidName.text = selectItem.itemName;
                    liquidType.text = selectItem.itemType.ToString();
                    liquidGrade.text = $"<color={sColorCode}>{selectItem.itemGrade}</color>";
                    liquidInfo.text = selectItem.info;
                    liquidMedicineUI.SetActive(true);
                }
                break;
            case ItemType.StatusRecovery:
                {
                    SFontColor();

                    statusImage.sprite = selectItem.itemImage;
                    statusName.text = selectItem.itemName;
                    statusType.text = selectItem.itemType.ToString();
                    statusGrade.text = $"<color={sColorCode}>{selectItem.itemGrade}</color>";
                    statusInfo.text = selectItem.info;
                    statusRecoveryUI.SetActive(true);
                }
                break;
            case ItemType.Expendables:
                {
                    SFontColor();

                    expendImage.sprite = selectItem.itemImage;
                    expendName.text = selectItem.itemName;
                    expendType.text = selectItem.itemType.ToString();
                    expendGrade.text = $"<color={sColorCode}>{selectItem.itemGrade}</color>";
                    expendInfo.text = selectItem.info;
                    expendablesUI.SetActive(true);
                }
                break;
            case ItemType.Equipment:
                {
                    ItemDataSO equipment = Equipment.Instance.equipment[(int)selectItem.slotType];

                    if (equipment != null)
                    {
                        //아이템 등급 타입에 맞춰서 색상변경
                        WFontColor(equipment);
                        SFontColor();

                        wImage.sprite = equipment.itemImage;
                        wName.text = equipment.itemName;
                        wGrade.text = $"<color={wColorCode}>{equipment.itemGrade}</color>";
                        wAttackPowerNum.text = equipment.attackPower.ToString();
                        wSkillPowerNum.text = equipment.skillPower.ToString();
                        wDefenceNum.text = equipment.defence.ToString();
                        wSpeedNum.text = equipment.speed.ToString();
                        wInfo.text = equipment.info;

                        sImage.sprite = selectItem.itemImage;
                        sName.text = selectItem.itemName;
                        sGrade.text = $"<color={sColorCode}>{selectItem.itemGrade}</color>";
                        sAttackPowerNum.text = selectItem.attackPower.ToString();
                        sSkillPowerNum.text = selectItem.skillPower.ToString();
                        sDefenceNum.text = selectItem.defence.ToString();
                        sSpeedNUm.text = selectItem.speed.ToString();
                        sInfo.text = selectItem.info;
                    }
                    else if (equipment == null)
                    {
                        SFontColor();

                        wImage.color = new Color(1, 1, 1, 0);
                        wName.text = "미착용 장비";
                        wGrade.text = "";
                        wAttackPowerNum.text = "";
                        wSkillPowerNum.text = "";
                        wDefenceNum.text = "";
                        wSpeedNum.text = "";
                        wInfo.text = "";

                        sImage.sprite = selectItem.itemImage;
                        sName.text = selectItem.itemName;
                        sGrade.text = $"<color={sColorCode}>{selectItem.itemGrade}</color>";
                        sAttackPowerNum.text = selectItem.attackPower.ToString();
                        sSkillPowerNum.text = selectItem.skillPower.ToString();
                        sDefenceNum.text = selectItem.defence.ToString();
                        sSpeedNUm.text = selectItem.speed.ToString();
                        sInfo.text = selectItem.info;
                    }

                    equipmentTypeUI.SetActive(true);
                }
                break;
            case ItemType.Etc:
                {

                }
                break;
        }
    }

    public void InventoryActiveUI()
    {

    }

    public void EquipActiveUI()
    {

    }

    public void WFontColor(ItemDataSO check)
    {
        if (check == null) return;

        switch (selectItem.itemGrade)
        {
            case ItemGrade.Common:
                {
                    wColorCode = "#ffffff";
                }
                break;
            case ItemGrade.Uncommon:
                {
                    wColorCode = "#a7d4f5";
                }
                break;
            case ItemGrade.Rare:
                {
                    wColorCode = "#cca7f5";
                }
                break;
            case ItemGrade.Epic:
                {
                    wColorCode = "#eabd95";
                }
                break;
            case ItemGrade.Legendary:
                {
                    wColorCode = "#f9e5a1";
                }
                break;
        }
    }

    public void SFontColor()
    {
        switch (selectItem.itemGrade)
        {
            case ItemGrade.Common:
                {
                    wColorCode = "#ffffff";
                }
                break;
            case ItemGrade.Uncommon:
                {
                    wColorCode = "#a7d4f5";
                }
                break;
            case ItemGrade.Rare:
                {
                    wColorCode = "#cca7f5";
                }
                break;
            case ItemGrade.Epic:
                {
                    wColorCode = "#eabd95";
                }
                break;
            case ItemGrade.Legendary:
                {
                    wColorCode = "#f9e5a1";
                }
                break;
        }
    }
    #endregion
}