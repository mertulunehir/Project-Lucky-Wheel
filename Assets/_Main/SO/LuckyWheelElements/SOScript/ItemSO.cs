using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemObject", order = 1)]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public Color rewardBackgroundColor;


    public bool IsItemBomb()
    {
        if (itemName.Equals("Bomb"))
            return true;
        else
            return false;
    }
    public bool IsItemCash()
    {
        if (itemName.Equals("Cash"))
            return true;
        else
            return false;
    }
    public bool IsItemGold()
    {
        if (itemName.Equals("Gold"))
            return true;
        else
            return false;
    }
}
