using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;
using System;

namespace LWheel.LuckyWheelNameSpace
{

    public class LuckyWheelButtonController : MonoBehaviour
    {
        [SerializeField] private Button rotateButton;

        private bool canPressButton;
        private Tween spinAnimTween;
        private Tween sizeAnimTween;

        [Inject] private LuckyWheel luckyWheel;

        private float buttonRotateTime;
        private float buttonSpinAnimDelay;
        private float buttonIdleAnimsizeMuiltiplier;
        private float buttonClickAnimsizeMuiltiplier;
        private Ease rotateEase;

        private void Start()
        {
            canPressButton = true;
            StartButtonRotateAnim();

        }
        private void OnRotateButtonPressed()
        {
            if (canPressButton)
            {
                canPressButton = false;
                luckyWheel.ChooseRewardAfterButtonClick();
                StopButtonRotateAnim();
                RotateAfterButtonClick();
                GrowAfterButtonClick();
            }
        }

        public void EnableButton()
        {
            StopButtonRotateAnim();
            canPressButton = true;
            StartButtonRotateAnim();
        }


        private void StartButtonRotateAnim()
        {
            if (canPressButton == true)
            {
                DOVirtual.DelayedCall(buttonSpinAnimDelay, RotateButton);
            }
        }

        private void RotateButton()
        {
            if(canPressButton==true)
            {
                sizeAnimTween = rotateButton.transform.DOScale(Vector3.one * buttonIdleAnimsizeMuiltiplier, buttonRotateTime * 0.3f).OnComplete(ButtonShrinkAnim);
                spinAnimTween = rotateButton.transform.DORotate(Vector3.forward*360, buttonRotateTime, RotateMode.LocalAxisAdd).SetEase(rotateEase).OnComplete(StartButtonRotateAnim);

            }
        }

        private void RotateAfterButtonClick()
        {
            spinAnimTween.Kill();
            rotateButton.transform.localEulerAngles = Vector3.zero;
            spinAnimTween = rotateButton.transform.DORotate(Vector3.forward * 360, buttonRotateTime, RotateMode.LocalAxisAdd).SetEase(rotateEase).OnComplete(StartButtonRotateAnim);

        }

        private void GrowAfterButtonClick()
        {
            sizeAnimTween = rotateButton.transform.DOScale(Vector3.one * buttonClickAnimsizeMuiltiplier, buttonRotateTime * 0.3f).OnComplete(ButtonShrinkAnim);
        }

        private void ButtonShrinkAnim()
        {
            sizeAnimTween = rotateButton.transform.DOScale(Vector3.one, buttonRotateTime * 0.7f);
        }

        private void StopButtonRotateAnim()
        {

            spinAnimTween.Kill();
            rotateButton.transform.localEulerAngles = Vector3.zero;

            sizeAnimTween.Kill();
            rotateButton.transform.localScale = Vector3.one;

        }

        private void OnEnable()
        {
            rotateButton.onClick.AddListener(OnRotateButtonPressed);
        }

        private void OnDisable()
        {
            rotateButton.onClick.RemoveListener(OnRotateButtonPressed);

        }

        public void SetDataFromSO(LuckyWheelSO luckyWheelSO)
        {
            buttonRotateTime = luckyWheelSO.buttonRotateTime;
            buttonSpinAnimDelay = luckyWheelSO.buttonSpinAnimDelay;
            buttonIdleAnimsizeMuiltiplier = luckyWheelSO.buttonIdleAnimsizeMuiltiplier;
            buttonClickAnimsizeMuiltiplier = luckyWheelSO.buttonClickAnimsizeMuiltiplier;
            rotateEase = luckyWheelSO.spinButtonRotateEase;
        }
    }
}
