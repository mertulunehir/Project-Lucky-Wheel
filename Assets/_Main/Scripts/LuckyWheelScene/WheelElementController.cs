using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelElementController : MonoBehaviour
{
    [SerializeField] private Image rewardIcon;
    [SerializeField] private TMP_Text rewardAmountText;

    public void SetWheelElementData(ItemSO currentItemSO, int rewardAmount)
    {
        rewardAmountText.text = rewardAmount.ToString();
        rewardIcon.sprite = currentItemSO.itemIcon;

        if (currentItemSO.IsItemBomb())
            rewardAmountText.gameObject.SetActive(false);
        else
            rewardAmountText.gameObject.SetActive(true);

    }

}
