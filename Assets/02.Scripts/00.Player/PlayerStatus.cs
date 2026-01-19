using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    #region field
    public static PlayerStatus Instance { get; private set; }

    [Header("스텟")]
    public float maxHp = 30.0f;
    public float hp = 30.0f;
    public float maxMp = 20.0f;
    public float mp = 20.0f;
    public int damage = 5;
    public int skillDamage = 0;
    public int defense = 0;
    public int speed = 10;

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
