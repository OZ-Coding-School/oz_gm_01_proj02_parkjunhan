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

[RequireComponent (typeof(Inventory))]
public class EquipMent : MonoBehaviour
{
    #region field
    public ItemDataSO[] equipment = new ItemDataSO[6];
    [SerializeField] EquipSlot[] equipSlots;

    public Inventory inventory;
    #endregion

    void Awake()
    {
        inventory = GetComponent<Inventory>();

        WearingEquipment();
    }

    void Update()
    {
        
    }

    #region method
    public void WearingEquipment()
    {
        for (int i = 0; i < equipSlots.Length; i++)
        {
            equipment[(int)equipSlots[i].slotType] = equipSlots[i].Item;
        }
    }

    //equipSlots에 아이탬 데이터 add
    #endregion
}