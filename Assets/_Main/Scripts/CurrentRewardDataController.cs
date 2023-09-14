using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrentRewardDataController : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text amount;

    private int currentAmount=1;

    public void SetCurrentItemRewardInformation(Sprite currentIcon)
    {
        amount.text = currentAmount.ToString();
        icon.sprite = currentIcon;
    }

    public void SetCurrentMoneyRewardInformation(Sprite currentIcon,int rewardAmount)
    {
        amount.text = rewardAmount.ToString();
        icon.sprite = currentIcon;
    }

    public void UpdateCurrentItemRewardAmount()
    {
        currentAmount++;
        amount.text = currentAmount.ToString();
    }

    public void UpdateCurrentMoneyRewardAmount(int rewardAmount)
    {
        currentAmount+=rewardAmount;
        amount.text = currentAmount.ToString();
    }


}
