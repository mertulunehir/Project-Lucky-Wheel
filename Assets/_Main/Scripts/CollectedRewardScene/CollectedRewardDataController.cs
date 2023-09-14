using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectedRewardDataController : MonoBehaviour
{
    public Image collectedRewardImage;
    public TMP_Text collectedRewardAmount;

    private ItemSO currentColletedItemSO;
    private int currentCollectedItemAmount = 0;

    public void SetCollectedRewardData(ItemSO collectedItem,int amount)
    {
        currentColletedItemSO = collectedItem;
        currentCollectedItemAmount = amount;
        collectedRewardImage.sprite = currentColletedItemSO.itemIcon;

        collectedRewardAmount.text = currentCollectedItemAmount.ToString();
    }

    public void UpdateCollectedRewardData(int amount)
    {
        currentCollectedItemAmount += amount;

        collectedRewardAmount.text = currentCollectedItemAmount.ToString();

    }

    public ItemSO GetItemSO()
    {
        return currentColletedItemSO;
    }

    public int GetItemAmount()
    {
        return currentCollectedItemAmount;
    }
}
