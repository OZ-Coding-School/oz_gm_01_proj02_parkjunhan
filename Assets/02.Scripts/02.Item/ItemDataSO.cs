using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "Add Item/Item")]
public class ItemDataSO : ScriptableObject
{
    [Header("기본 정보")]
    public string itemName;
    public int attackPower;
    public int skillPower;
    public int defence;
    public float speed;
    public int price;
    public Sprite itemImage;
    public int counter; //판매 갯수

    [Header("소비 아이템")]
    public bool expendables;

    //물약
    public int recoveryHp;
    public int recoveryMp;

    //상태이상 회복물약
    public bool bleeding;
    public bool poison;
    public bool electricShock;
    public bool faint;
    public bool horror;

    //스크롤
    public SkillList skillList;

    [Header("장비 아이템")]
    public EquipSlotType slotType;
    public bool equipment;

    //무기 스킬
    public SkillList weaponSkill;
}
