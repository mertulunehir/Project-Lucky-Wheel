using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace LWheel.LuckyWheelNameSpace
{

    public class LuckyWheelButtonController : MonoBehaviour
    {
        [SerializeField] private Button rotateButton;

        private bool canPressButton;
        [Inject]private LuckyWheel luckyWheel;

        private void Start()
        {
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
}
