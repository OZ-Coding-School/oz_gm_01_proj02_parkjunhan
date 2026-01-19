using UnityEngine;

public enum EquipSlotType
{
    Helmet,
    Armor,
    Gloves,
    Pants,
    Shoes,
    Weapon
}

public class Equipment : MonoBehaviour
{
    #region field
    public ItemDataSO[] equipment = new ItemDataSO[6];
    [SerializeField] EquipSlot[] equipSlots = new EquipSlot[6];

    public Inventory inventory;

    [Header("¿Â∫Ò≈« UI")]
    [SerializeField] public GameObject equipmentUI;
    #endregion

    void Awake()
    {
        inventory = GetComponent<Inventory>();
        equipmentUI = GameObject.Find("Canvas").transform.Find("EquipeUI").gameObject;
        if (equipmentUI.gameObject.activeInHierarchy) equipmentUI.SetActive(false);

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