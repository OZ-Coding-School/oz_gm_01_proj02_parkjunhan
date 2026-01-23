using UnityEngine;

public class EquipmentUI : MonoBehaviour
{
    #region field
    [SerializeField] Transform equipParent;
    [SerializeField] EquipSlot[] equipSlots = new EquipSlot[6];

    [Header("데이터 연동")]
    ItemDataSO[] equipment;

    [Header("장비탭 UI")]
    [SerializeField] public GameObject equipmentUI;
    #endregion

    void Awake()
    {
        Setting();
        RefreshSlot();
    }

    void Update()
    {
        if (EquipmentManager.Instance.needRefresh)
        {
            RefreshSlot();
            EquipmentManager.Instance.needRefresh = false;
        }
    }

    #region method
    void Setting()
    {
        equipParent = transform.Find("SlotParent");
        equipSlots = equipParent.GetComponentsInChildren<EquipSlot>();

        equipment = Equipment.Instance.equipment;

        equipmentUI = gameObject;
    }

    public void RefreshSlot()
    {
        if (equipment == null) return;

        for (int i = 0; i < equipSlots.Length; i++)
        {
            if (equipment[i] != null)
            {
                equipSlots[(int)equipment[i].slotType].Item = equipment[i];
            }
            else if (equipment[i] == null)
            {
                equipSlots[i] = null;
            }
        }
    }
    #endregion
}