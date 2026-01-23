using UnityEngine;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    #region field
    public static ShopManager Instance;

    //아이템 정보 UI
    public ShopSlot shopSlot;
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

    void Update()
    {
        
    }

    #region method
    public void OnShopClicked(ShopSlot slot, PointerEventData eventData)
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
                    shopSlot = slot;
                }
                break;
        }
    }
    #endregion
}