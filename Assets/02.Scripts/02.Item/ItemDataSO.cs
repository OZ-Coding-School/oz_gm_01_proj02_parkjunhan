using UnityEngine;

public enum ItemType
{
    LiquidMedicine,
    StatusRecovery,
    Expendables,
    Equipment,
    Etc
}

public enum ItemGrade
{
    Common,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "Item_", menuName = "Add Item/Item")]
public class ItemDataSO : ScriptableObject
{
    [Header("기본 정보")]
    public string itemName;
    public int price;
    public Sprite itemImage;
    public int counter; //판매 갯수

    [Header("아이템 종류")]
    public ItemType itemType;

    [Header("아이템 등급")]
    public ItemGrade itemGrade;

    [Header("물약")]
    public int recoveryHp;
    public int recoveryMp;

    [Header("상태회복 물약")]
    //상태이상 회복물약
    public bool bleeding;
    public bool poison;
    public bool electricShock;
    public bool faint;
    public bool horror;

    [Header("소모품")]
    //스크롤
    public SkillList skillList;

    [Header("장비 아이템")]
    public EquipSlotType slotType;

    public int attackPower;
    public int skillPower;
    public int defence;
    public float speed;

    //무기 스킬
    public SkillList weaponSkill;
}
