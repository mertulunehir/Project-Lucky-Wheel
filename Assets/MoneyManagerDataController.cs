using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManagerDataController : MonoBehaviour
{
    private int currentGoldAmount,currentCashAmount;

    private void Awake()
    {
        CheckForSaveData();
    }

    private void CheckForSaveData()
    {
        if(PlayerPrefs.HasKey("Cash"))
        {
            currentCashAmount = PlayerPrefs.GetInt("Cash");
        }
        else
        {
            PlayerPrefs.SetInt("Cash",0);
            currentCashAmount = PlayerPrefs.GetInt("Cash");
        }

        if (PlayerPrefs.HasKey("Gold"))
        {
            currentGoldAmount = PlayerPrefs.GetInt("Gold");
        }
        else
        {
            PlayerPrefs.SetInt("Gold", 0);
            currentGoldAmount = PlayerPrefs.GetInt("Gold");
        }
    }

    public void UpdateCashAmount(int amount)
    {
        currentCashAmount += amount;
        PlayerPrefs.SetInt("Cash", currentCashAmount);
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
        PlayerPrefs.SetInt("Gold", currentGoldAmount);
    }
}
