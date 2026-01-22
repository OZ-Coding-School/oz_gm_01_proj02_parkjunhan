using TMPro;
using UnityEngine;

public class ConfirmUI : MonoBehaviour
{
    #region field
    TextMeshProUGUI subText;
    GameObject UI;
    #endregion

    void Awake()
    {
        subText = transform.Find("SubText").GetComponent<TextMeshProUGUI>();
        UI = gameObject;
    }

    private void Update()
    {
        if (EquipmentManager.Instance.needConfirm)
        {
            UI.SetActive(true);
        }
    }

    #region method
    public void ClickedY()
    {
        EquipmentManager.Instance.needRefresh = true;
        EquipmentManager.Instance.needConfirm = false;
        UI.SetActive(false);
    }

    public void ClickedN()
    {
        EquipmentManager.Instance.needConfirm = false;
        UI.SetActive(false);
    }
    #endregion
}