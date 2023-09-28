using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWheel.MoneyManagerNameSpace
{

    public class MoneyManagerDataController : MonoBehaviour
    {
        private int currentGoldAmount;
        private int currentCashAmount;
        private string cashSaveKey;
        private string goldSaveKey;

        private void Start()
        {
            CheckForSaveData();
        }

        public void SetDataFromSO(MoneyManagerSO moneyManagerSO)
        {
            cashSaveKey = moneyManagerSO.cashSaveKey;
            goldSaveKey = moneyManagerSO.goldSaveKey;
        }

        private void CheckForSaveData()
        {
            if (PlayerPrefs.HasKey(cashSaveKey))
            {
                currentCashAmount = PlayerPrefs.GetInt(cashSaveKey);
            }
            else
            {
                PlayerPrefs.SetInt(cashSaveKey, 0);
                currentCashAmount = PlayerPrefs.GetInt(cashSaveKey);
            }

            if (PlayerPrefs.HasKey(goldSaveKey))
            {
                currentGoldAmount = PlayerPrefs.GetInt(goldSaveKey);
            }
            else
            {
                PlayerPrefs.SetInt(goldSaveKey, 0);
                currentGoldAmount = PlayerPrefs.GetInt(goldSaveKey);
            }
        }

        public void UpdateCashAmount(int amount)
        {
            currentCashAmount += amount;
            PlayerPrefs.SetInt(cashSaveKey, currentCashAmount);
        }

        public int GetCashAmount()
        {
            return currentCashAmount;
        }
        public int GetGoldAmount()
        {
            return currentGoldAmount;
        }
        public void UpdateGoldAmount(int amount)
        {
            currentGoldAmount += amount;
            PlayerPrefs.SetInt(goldSaveKey, currentGoldAmount);
        }
    }
}
