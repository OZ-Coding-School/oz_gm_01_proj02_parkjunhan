using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    #region field
    public static PlayerStatus Instance { get; private set; }

    [Header("스텟")]
    public float maxHp = 20.0f;
    public float hp = 20.0f;
    public float maxMp = 15.0f;
    public float mp = 15.0f;

    public int strength = 1;
    public int dexterity = 1;
    public int intellect = 1;
    public int luck = 1;

    [Header("장비스텟")]
    public int attackPower;
    public int skillPower;
    public int defence;
    public int speed;

    [Header("상태이상")]
    public bool bleeding;
    public bool poison;
    public bool electricShock;
    public bool faint;
    public bool horror;

    [Header("화폐")]
    public int gold = 10;
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
    public void ModifyHp(float hp)
    {
        if (this.hp >= maxHp)
        {
            Debug.Log("최대체력");
            return;
        }
        else if (this.hp < maxHp)
        {
            this.hp += hp;

            if (this.hp > maxHp) this.hp = maxHp;
        }
    }

    public void ModifyMp(float mp)
    {
        if (this.mp >= maxMp)
        {
            Debug.Log("최대마력");
            return;
        }
        else if (this.mp < maxMp)
        {
            this.mp += mp;

            if (this.mp > maxMp) this.mp = maxMp;
        }
    }
    #endregion
}
