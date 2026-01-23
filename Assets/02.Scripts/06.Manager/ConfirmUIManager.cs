using TMPro;
using UnityEngine;

public class ConfirmUIManager : MonoBehaviour
{
    #region field
    [Header("장비탭 UI 및 구성요소")]
    [SerializeField] GameObject equipmentUI;
    [SerializeField] TextMeshProUGUI equipmentSubText;

    //타입 데이터 가져오기
    ItemType itemType;
    ItemGrade itemGrade;
    string colorCode = "";
    #endregion

    void Awake()
    {
        Setting();
    }

    private void Update()
    {
        Request();
    }

    #region method
    public void Setting()
    {
        //장비탭 UI 및 구성요소
        equipmentUI = GameObject.Find("ConfirmUI/Equipment");
        equipmentSubText = GameObject.Find("ConfirmUI/Equipment/SubText").GetComponent<TextMeshProUGUI>();
    }

    public void Request()
    {
        if (EquipmentManager.Instance.needConfirm)
        {
            //타입에 맞춰서 UI 구성 셋팅
            itemType = EquipmentManager.Instance.type;
            itemGrade = EquipmentManager.Instance.grade;
            FontColor();
            TypeCheck();

            equipmentUI.SetActive(true);
        }
    }

    //타입 체크 후 해당 타입 UI 셋팅
    public void TypeCheck()
    {
        switch (itemType)
        {
            case ItemType.LiquidMedicine:
                {

                }
                break;
            case ItemType.StatusRecovery:
                {

                }
                break;
            case ItemType.Expendables:
                {

                }
                break;
            case ItemType.Equipment:
                {
                    equipmentSubText.text = $"<color={colorCode}>{EquipmentManager.Instance.selectItemName}</color>" +
                        $" 장비를 해제합니다.";
                }
                break;
            case ItemType.Etc:
                {

                }
                break;
        }
    }

    public void ClickedY()
    {
        switch (itemType)
        {
            case ItemType.LiquidMedicine:
                {

                }
                break;
            case ItemType.StatusRecovery:
                {

                }
                break;
            case ItemType.Expendables:
                {

                }
                break;
            case ItemType.Equipment:
                {
                    EquipmentManager.Instance.selectY = true;
                    EquipmentManager.Instance.needConfirm = false;
                    equipmentUI.SetActive(false);
                }
                break;
            case ItemType.Etc:
                {

                }
                break;
        }

    }

    public void ClickedN()
    {
        switch (itemType)
        {
            case ItemType.LiquidMedicine:
                {

                }
                break;
            case ItemType.StatusRecovery:
                {

                }
                break;
            case ItemType.Expendables:
                {

                }
                break;
            case ItemType.Equipment:
                {
                    EquipmentManager.Instance.needConfirm = false;
                    equipmentUI.SetActive(false);
                }
                break;
            case ItemType.Etc:
                {

                }
                break;
        }
    }

    //아이탬 타입별로 폰트 색상 변경
    public void FontColor()
    {
        switch (itemGrade)
        {
            case ItemGrade.Common:
                {
                    colorCode = "#ffffff";
                }
                break;
            case ItemGrade.Uncommon:
                {
                    colorCode = "#a7d4f5";
                }
                break;
            case ItemGrade.Rare:
                {
                    colorCode = "#cca7f5";
                }
                break;
            case ItemGrade.Epic:
                {
                    colorCode = "#eabd95";
                }
                break;
            case ItemGrade.Legendary:
                {
                    colorCode = "#f9e5a1";
                }
                break;
        }
    }
    #endregion
}