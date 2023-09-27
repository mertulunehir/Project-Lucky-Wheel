using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace LWheel.MoneyManagerNameSpace
{
    public class MoneyManagerCanvasController : MonoBehaviour
    {
        [SerializeField] private TMP_Text goldText, cashText;

        public void UpdateCashText(int currentCashAmount)
        {
            cashText.text = currentCashAmount.ToString();
        }
        public void UpdateCashText(int currentCashAmount, int collectedAmount)
        {
            DOTween.To(() => currentCashAmount, x => currentCashAmount = x, currentCashAmount + collectedAmount, 1).OnUpdate(() => cashText.text = currentCashAmount.ToString());
        }

        public void UpdateGoldText(int currentGoldAmount)
        {
            goldText.text = currentGoldAmount.ToString();
        }

        public void UpdateGoldText(int currentGoldAmount, int collectedAmount)
        {
            DOTween.To(() => currentGoldAmount, x => currentGoldAmount = x, currentGoldAmount + collectedAmount, 1).OnUpdate(() => goldText.text = currentGoldAmount.ToString());
        }
    }

}
