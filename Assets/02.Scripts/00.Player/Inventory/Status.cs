using TMPro;
using UnityEngine;

public class Status : MonoBehaviour
{
    #region field
    PlayerStatus status;

    [Header("Ä³¸¯ÅÍ ½ºÅÝ")]
    TextMeshProUGUI str;
    TextMeshProUGUI dex;
    TextMeshProUGUI intel;
    TextMeshProUGUI luk;

    [Header("Àåºñ ½ºÅÝ")]
    TextMeshProUGUI ap;
    TextMeshProUGUI sp;
    TextMeshProUGUI defense;
    TextMeshProUGUI speed;
    #endregion

    void Awake()
    {
        Setting();
    }

    private void Start()
    {
        status = PlayerStatus.Instance;
        FreshStatus();
    }

    void Update()
    {
        
    }

    #region method
    void Setting()
    {
        str = GameObject.Find("Background/StatusTexts_1/CurrentStatus/CurrentStr")
            .GetComponent<TextMeshProUGUI>();
        dex = GameObject.Find("Background/StatusTexts_1/CurrentStatus/CurrentDex")
            .GetComponent<TextMeshProUGUI>();
        intel = GameObject.Find("Background/StatusTexts_1/CurrentStatus/CurrentInt")
            .GetComponent<TextMeshProUGUI>();
        luk = GameObject.Find("Background/StatusTexts_1/CurrentStatus/CurrentLuk")
            .GetComponent<TextMeshProUGUI>();

        ap = GameObject.Find("Background/StatusTexts_2/CurrentStatus/CurrentAttackPower")
            .GetComponent<TextMeshProUGUI>();
        sp = GameObject.Find("Background/StatusTexts_2/CurrentStatus/CurrentSkillPower")
            .GetComponent<TextMeshProUGUI>();
        defense = GameObject.Find("Background/StatusTexts_2/CurrentStatus/CurrentDefence")
            .GetComponent<TextMeshProUGUI>();
        speed = GameObject.Find("Background/StatusTexts_2/CurrentStatus/CurrentSpeed")
            .GetComponent<TextMeshProUGUI>();
    }

    void FreshStatus()
    {
        str.text = status.strength.ToString();
        dex.text = status.dexterity.ToString();
        intel.text = status.intellect.ToString();
        luk.text = status.luck.ToString();

    }
    #endregion
}