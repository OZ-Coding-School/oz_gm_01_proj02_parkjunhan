using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    #region field
    static ShopManager instance;
    public static ShopManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ShopManager();
            }
            return instance;
        }
    }

    ShopManager() { } //방어코드
    #endregion

    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    #region method
    public void OnShopClicked(Slot slot, PointerEventData eventData)
    {
        if (slot.Item == null) return;

        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                {
                    //아이템 구매
                    //confirm UI 활성화
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