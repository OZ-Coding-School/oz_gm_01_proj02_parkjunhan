using Unity.VisualScripting;

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

public class Equipment
{
    #region field
    static Equipment instance;
    public static Equipment Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Equipment();
            }
            return instance;
        }
    }

    Equipment() { } //방어코드

    public ItemDataSO[] equipment = new ItemDataSO[6];
    #endregion

    #region method
    public void AddEquipment(Slot slot)
    {
        equipment[(int)slot.Item.slotType] = slot.Item;
        EquipmentManager.Instance.needRefresh = true;
    }

    public void RemoveEquipment(Slot slot)
    {
        equipment[(int)slot.Item.slotType] = null; 
        EquipmentManager.Instance.needRefresh = true;
    }
    #endregion
}