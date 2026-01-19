using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour
{
    #region field
    [SerializeField] Image itemImage;
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemCounter;

    ItemDataSO _item;
    public ItemDataSO Item
    {
        get { return _item; }
        set
        {
            _item = value;
            Debug.Log($"itemImage's null? {itemImage == null}");
            if (_item != null)
            {
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
            }
            else
            {
                //itemImage.sprite = null;
                itemImage.color = new Color(1, 1, 1, 0);
                itemName.text = "";
                itemCounter.text = "";
            }
        }
    }
    #endregion

    protected virtual void Awake()
    {
        itemImage = transform.Find("ItemImage").GetComponent<Image>();
        itemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
        itemCounter = transform.Find("ItemCounter").GetComponent<TextMeshProUGUI>();

        if (itemImage != null) itemImage.raycastTarget = false;
        if (itemName != null) itemName.raycastTarget = false;
        if (itemCounter != null) itemCounter.raycastTarget = false;
    }

    protected virtual void Update()
    {
        if (_item != null)
        {
            if (itemCounter == null) return;
            if (_item.counter > 0) itemCounter.text = "" + _item.counter;
        }
    }
}