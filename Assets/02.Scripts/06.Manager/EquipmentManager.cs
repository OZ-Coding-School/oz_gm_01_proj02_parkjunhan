using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentManager : MonoBehaviour
{
    #region field
    public static EquipmentManager Instance { get; private set; }

    Equipment equipment;

    //확인절차 필요 시
    public bool needRefresh = false;
    public bool needConfirm = false;
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

        equipment = Equipment.Instance;
    }

    void Update()
    {
        
    }

    #region method
    //플레이어 장비창
    public void OnEquipmentClicked(Slot slot, PointerEventData eventData)
    {
        if (slot.Item == null) return;

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                {
                    //장비 아이템 해제
                    needConfirm = true;
                }
                break;
            case PointerEventData.InputButton.Right:
                {
                    //아이템 정보
                }
                break;
        }
    }
    #endregion
}