using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/ItemObject", order = 1)]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public Color rewardBackgroundColor;
}
