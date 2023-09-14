using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LuckyWheelZoneController : MonoBehaviour
{
    private int currentZoneNumber = 1;

    [SerializeField] private TMP_Text zoneInfoText;

    private void Start()
    {
        SetZoneInfoText();
    }
    public void ResetZoneNumber()
    {
        currentZoneNumber = 1;
        SetZoneInfoText();
    }

    public void UpdateZoneNumber()
    {
        currentZoneNumber++;
        SetZoneInfoText();
    }

    public int GetZoneNumber()
    {
        return currentZoneNumber;
    }

    private void SetZoneInfoText()
    {
        string infotext;
        infotext = GetZoneNumberTextInString(currentZoneNumber) + " Round!";
        zoneInfoText.text = infotext;
    }

    private string GetZoneNumberTextInString(int currentZone)
    {
        string tmpZoneText;
        switch (currentZone)
        {
            
            case 1:
                tmpZoneText =  currentZone.ToString() + "st";
                break;
            case 2:
                tmpZoneText = currentZone.ToString() + "nd";

                break;
            case 3:
                tmpZoneText = currentZone.ToString() + "rd";

                break;
            default:
                tmpZoneText = currentZone.ToString() + "th";
                break;

        }

        return tmpZoneText;
    }
}
