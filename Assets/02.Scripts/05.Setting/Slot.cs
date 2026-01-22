using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour
{
    #region field
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemCounter;
    [SerializeField] TextMeshProUGUI itemPrice;

    ItemDataSO _item;
    public ItemDataSO Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                Debug.Log("test");
                if (_item.itemImage != null)
                {
                    itemImage.sprite = Item.itemImage;
                    itemImage.color = new Color(1, 1, 1, 1);
                }
                else
                {
                    itemImage.sprite = null;
                    itemImage.color = new Color(1, 1, 1, 0);
                }

                if (_item.itemName != null)
                {
                    itemName.text = "" + _item.itemName;
                }
                else
                {
                    itemName.text = "";
                }

                if (_item.counter > 1)
                {
                    itemCounter.text = "" + _item.counter;
                }
                else
                {
                    itemCounter.text = "";
                }

                if (_item.price > 1)
                {
                    itemPrice.text = "" + _item.price;
                }
                else
                {
                    itemPrice.text = "";
                }
            }
            else
            {
                ClearUI();
            }
        }
    }
    #endregion

    protected virtual void Awake()
    {
        Setting();
        RefreshUI();
    }

    protected virtual void Update()
    {
        if (_item != null)
        {
            if (itemCounter == null) return;
            if (_item.counter > 0) itemCounter.text = "" + _item.counter;
        }
    }

    #region method
    void Setting()
    {
        itemImage = transform.Find("ItemImage").GetComponent<Image>();
        itemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();

        Transform counter = transform.Find("ItemCounter");
        if (counter != null) itemCounter = transform.Find("ItemCounter").GetComponent<TextMeshProUGUI>();
        Transform price = transform.Find("ItemPrice");
        if (price != null) itemPrice = transform.Find("ItemPrice").GetComponent<TextMeshProUGUI>();

        if (itemImage != null) itemImage.raycastTarget = false;
        if (itemName != null) itemName.raycastTarget = false;
        if (itemCounter != null) itemCounter.raycastTarget = false;
        if (itemPrice != null) itemPrice.raycastTarget = false;
    }

    void RefreshUI()
    {
        if (_item == null)
        {
            ClearUI();
            return;
        }
    }

    void ClearUI()
    {
        if (itemImage != null)
        {
            itemImage.sprite = null;
            itemImage.color = new Color(1, 1, 1, 0);
        }
        if (itemName != null) itemName.text = "";
        if (itemCounter != null) itemCounter.text = "";
        if (itemPrice != null) itemPrice.text = "";
    }
    #endregion
}