using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelElementController : MonoBehaviour
{
    [SerializeField] private Image rewardIcon;
    [SerializeField] private TMP_Text rewardAmountText;

    private ItemSO currentItemSO;
    private int rewardAmount;

    public void SetWheelElementData(ItemSO currentItemSO, int rewardAmount)
    {
        this.currentItemSO = currentItemSO;
        this.rewardAmount = rewardAmount;

        rewardAmountText.text = rewardAmount.ToString();
        rewardIcon.sprite = currentItemSO.itemIcon;
    }

}
