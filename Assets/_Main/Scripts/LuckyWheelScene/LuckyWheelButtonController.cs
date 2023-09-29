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

        public float buttonRotateTime = 1;
        public float buttonSpinAnimDelay = 1;
        public Ease rotateEase = Ease.OutBack;

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
                sizeAnimTween = rotateButton.transform.DOScale(Vector3.one * 1.1f, buttonRotateTime * 0.3f).OnComplete(ButtonShrinkAnim);
                spinAnimTween = rotateButton.transform.DORotate(new Vector3(0, 0, 360), buttonRotateTime, RotateMode.LocalAxisAdd).SetEase(rotateEase).OnComplete(StartButtonRotateAnim);

            }
        }

        private void RotateAfterButtonClick()
        {
            spinAnimTween.Kill();
            rotateButton.transform.localEulerAngles = Vector3.zero;
            spinAnimTween = rotateButton.transform.DORotate(new Vector3(0, 0, 360), buttonRotateTime, RotateMode.LocalAxisAdd).SetEase(rotateEase).OnComplete(StartButtonRotateAnim);

        }

        private void GrowAfterButtonClick()
        {
            sizeAnimTween = rotateButton.transform.DOScale(Vector3.one * 1.3f, buttonRotateTime * 0.3f).OnComplete(ButtonShrinkAnim);
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

    }
}
