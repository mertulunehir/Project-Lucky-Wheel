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

        private bool _canPressButton;
        private Tween _spinAnimTween;
        private Tween _sizeAnimTween;

        [Inject] private LuckyWheel luckyWheel;

        private float _buttonRotateTime;
        private float _buttonSpinAnimDelay;
        private float _buttonIdleAnimsizeMuiltiplier;
        private float _buttonClickAnimsizeMuiltiplier;
        private Ease _rotateEase;

        private void Start()
        {
            _canPressButton = true;
            StartButtonRotateAnim();

        }
        private void OnRotateButtonPressed()
        {
            if (_canPressButton)
            {
                _canPressButton = false;
                luckyWheel.ChooseRewardAfterButtonClick();
                StopButtonRotateAnim();
                RotateAfterButtonClick();
                GrowAfterButtonClick();
            }
        }

        public void EnableButton()
        {
            StopButtonRotateAnim();
            _canPressButton = true;
            StartButtonRotateAnim();
        }


        private void StartButtonRotateAnim()
        {
            if (_canPressButton == true)
            {
                DOVirtual.DelayedCall(_buttonSpinAnimDelay, RotateButton);
            }
        }

        private void RotateButton()
        {
            if(_canPressButton == true)
            {
                _sizeAnimTween = rotateButton.transform.DOScale(Vector3.one * _buttonIdleAnimsizeMuiltiplier, _buttonRotateTime * 0.3f).OnComplete(ButtonShrinkAnim);
                _spinAnimTween = rotateButton.transform.DORotate(Vector3.forward*360, _buttonRotateTime, RotateMode.LocalAxisAdd).SetEase(_rotateEase).OnComplete(StartButtonRotateAnim);

            }
        }

        private void RotateAfterButtonClick()
        {
            _spinAnimTween.Kill();
            rotateButton.transform.localEulerAngles = Vector3.zero;
            _spinAnimTween = rotateButton.transform.DORotate(Vector3.forward * 360, _buttonRotateTime, RotateMode.LocalAxisAdd).SetEase(_rotateEase).OnComplete(StartButtonRotateAnim);

        }

        private void GrowAfterButtonClick()
        {
            _sizeAnimTween = rotateButton.transform.DOScale(Vector3.one * _buttonClickAnimsizeMuiltiplier, _buttonRotateTime * 0.3f).OnComplete(ButtonShrinkAnim);
        }

        private void ButtonShrinkAnim()
        {
            _sizeAnimTween = rotateButton.transform.DOScale(Vector3.one, _buttonRotateTime * 0.7f);
        }

        private void StopButtonRotateAnim()
        {

            _spinAnimTween.Kill();
            rotateButton.transform.localEulerAngles = Vector3.zero;

            _sizeAnimTween.Kill();
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
            _buttonRotateTime = luckyWheelSO.buttonRotateTime;
            _buttonSpinAnimDelay = luckyWheelSO.buttonSpinAnimDelay;
            _buttonIdleAnimsizeMuiltiplier = luckyWheelSO.buttonIdleAnimsizeMuiltiplier;
            _buttonClickAnimsizeMuiltiplier = luckyWheelSO.buttonClickAnimsizeMuiltiplier;
            _rotateEase = luckyWheelSO.spinButtonRotateEase;
        }
    }
}
