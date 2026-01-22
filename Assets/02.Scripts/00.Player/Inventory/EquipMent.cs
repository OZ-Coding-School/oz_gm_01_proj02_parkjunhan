using UnityEngine;

public enum EquipSlotType
{
    Helmet,
    Armor,
    Gloves,
    Pants,
    Shoes,
    Weapon,
    None
}

public class Equipment : MonoBehaviour
{
    #region field
    public ItemDataSO[] equipment = new ItemDataSO[6];
    [SerializeField] Transform equipParent;
    [SerializeField] EquipSlot[] equipSlots = new EquipSlot[6];

    [Header("¿Â∫Ò≈« UI")]
    [SerializeField] public GameObject equipmentUI;
    #endregion

    void Awake()
    {
        equipParent = GameObject.Find("GameObject/Canvas/UI/PlayerUI/EquipeUI")
            .transform.Find("SlotParent");

        equipSlots = equipParent.GetComponentsInChildren<EquipSlot>();

        equipmentUI = GameObject.Find("GameObject/Canvas/UI/PlayerUI/EquipeUI");

        WearingEquipment();
    }

    void Update()
    {
        
    }

    #region method
    public void WearingEquipment()
    {
        if (equipment[0] == null) return;

        for (int i = 0; i < equipSlots.Length; i++)
        {
            equipment[(int)equipSlots[i].slotType] = equipSlots[i].Item;
        }
    }

    public void ClickedEquip(Slot slot)
    {
        for (int i = 0; i <equipSlots.Length; i++)
        {
            if (equipSlots[i] != null) continue;

            equipSlots[i] = (EquipSlot)slot;
        }
    }
    #endregion
}