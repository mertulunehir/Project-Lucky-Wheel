using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ZoneNumberUIController : MonoBehaviour
{
    public TMP_Text numberText;
    public Image backgroundImage;

    public void SetUIData(int number,Color backgroundColor)
    {
        numberText.text = number.ToString();
        backgroundImage.color = backgroundColor;
    }
}
