using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

namespace LWheel.MoneyManagerNameSpace
{
    public class MoneyManagerCanvasController : MonoBehaviour
    {
        [SerializeField] private TMP_Text goldText;
        [SerializeField] private TMP_Text cashText;

        public void UpdateCashText(int currentCashAmount)
        {
            cashText.text = currentCashAmount.ToString();
        }
        public void UpdateCashText(int currentCashAmount, int collectedAmount)
        {
            float GetCashAmount()
            {
                return currentCashAmount;
            }

            void UpdateCashText(float value)
            {
                currentCashAmount = (int)value;
                cashText.text = currentCashAmount.ToString();
            }

            float targetCashAmount = currentCashAmount + collectedAmount;
            var tweener = DOTween.To(GetCashAmount, UpdateCashText, targetCashAmount, 1f);
        }

        public void UpdateGoldText(int currentGoldAmount)
        {
            goldText.text = currentGoldAmount.ToString();
        }

        public void UpdateGoldText(int currentGoldAmount, int collectedAmount)
        {
            float GetGoldAmont()
            {
                return currentGoldAmount;
            }

            void UpdateGoldText(float value)
            {
                currentGoldAmount = (int)value;
                goldText.text = currentGoldAmount.ToString();
            }

            float targetCashAmount = currentGoldAmount + collectedAmount;
            var tweener = DOTween.To(GetGoldAmont, UpdateGoldText, targetCashAmount, 1f);
        }

    }

}
