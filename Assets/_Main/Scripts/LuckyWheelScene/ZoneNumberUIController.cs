using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ZoneNumberUIController : MonoBehaviour
{
    [SerializeField]private TMP_Text numberText;
    [SerializeField] private Image backgroundImage;

    public void SetUIData(int number,Color backgroundColor)
    {
        numberText.text = number.ToString();
        backgroundImage.color = backgroundColor;
    }
}
