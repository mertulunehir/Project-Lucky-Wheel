using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class MoneyManagerCanvasController : MonoBehaviour
{
    [SerializeField] private TMP_Text goldText,cashText;

    public void UpdateCashText(int currentCashAmount)
    {
        cashText.text = currentCashAmount.ToString();
    }
    public void UpdateCashText(int currentCashAmount,int collectedAmount)
    {

    }

    public void UpdateGoldText(int currentGoldAmount)
    {
        goldText.text = currentGoldAmount.ToString();
    }

    public void UpdateGoldText(int currentGoldAmount, int collectedAmount)
    {

    }
}
