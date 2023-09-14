using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyWheelButtonController : MonoBehaviour
{
    [SerializeField] private Button rotateButton;

    private bool canPressButton;
    private LuckyWheel luckyWheel;

    private void Start()
    {
        luckyWheel = GetComponent<LuckyWheel>();
        canPressButton = true;
    }
    private void OnRotateButtonPressed()
    {
        if (canPressButton)
        {
            canPressButton = false;
            luckyWheel.ChooseRewardAfterButtonClick();
        }
    }

    public void EnableButton()
    {
        canPressButton = true;
    }

    private void OnEnable()
    {
        rotateButton.onClick.AddListener(OnRotateButtonPressed);

    }

    private void OnDisable()
    {
        rotateButton.onClick.RemoveListener(OnRotateButtonPressed);

    }
}
