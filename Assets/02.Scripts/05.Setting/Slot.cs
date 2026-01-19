using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Slot : MonoBehaviour
{
    #region field
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI itemCounter;

    ItemDataSO _item;
    public ItemDataSO Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item != null)
            {
                if (_item.itemImage != null)
                {
                    image.sprite = Item.itemImage;
                    image.color = new Color(1, 1, 1, 1);
                }
                else
                {
                    image.sprite = null;
                    image.color = new Color(1, 1, 1, 0);
                }

                if (itemCounter != null)
                {
                    if (_item.counter > 0)
                    {
                        itemCounter.text = "" + _item.counter;
                    }
                    else
                    {
                        itemCounter.text = "";
                    }
                }
            }
            else
            {
                image.sprite = null;
                image.color = new Color(1, 1, 1, 0);
                if (itemCounter != null) itemCounter.text = "";
            }
        }
    }

    #endregion

    protected virtual void Awake()
    {
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