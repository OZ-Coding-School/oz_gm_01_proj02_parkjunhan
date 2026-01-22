using System.Collections.Generic;

public class Inventory
{
    #region field
    //C# ½Ì±ÛÅæ ÆÐÅÏ : https://math-development-geometry.tistory.com/58
    static Inventory instance;
    public static Inventory Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Inventory();
            }

            return instance;
        }
    }

    Inventory() { } //¹æ¾îÄÚµå

    public List<ItemDataSO> items;
    #endregion

    #region method
    public void AddItem(ItemDataSO item)
    {
        ItemDataSO duplication = null;

        if (item.recoveryHp > 0 && item.recoveryMp == 0)
        {
            duplication = items.Find(x => x.recoveryHp > 0);
        }
        else if (item.recoveryMp > 0 && item.recoveryHp == 0)
        {
            duplication = items.Find(x => x.recoveryMp > 0);
        }

        if (duplication != null)
        {
            duplication.counter++;
        }
        else if (duplication == null)
        {
            items.Add(item);
        }
    }

    public void RemoveItem(ItemDataSO item)
    {
        if (item == null) return;

        items.Remove(item);
    }
    #endregion
}