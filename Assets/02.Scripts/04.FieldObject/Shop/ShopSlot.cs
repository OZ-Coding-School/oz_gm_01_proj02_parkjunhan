using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopSlot : Slot, IPointerClickHandler
{
    Image coinImage;

    protected override void Awake()
    {
        base.Awake();
        coinImage = transform.Find("Image").GetComponent<Image>();
        if (Item == null) coinImage.color = new Color(1, 1, 1, 0);
    }

    protected override void Update()
    {
        base.Update();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (ShopManager.Instance != null)
        {
            ShopManager.Instance.OnShopClicked(this, eventData);
        }
    }
}
