using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace LWheel.RewardSceneNamespace
{
    public class RewardSceneAnimationController : MonoBehaviour
    {
        [SerializeField] private Transform cardParentTransform;
        [SerializeField] private Transform glowImageTransform;
        [SerializeField] private Transform glowBackgroundImageTransform;

        private float _cardShakeDuration;
        private float _cardShakeStrenght;
        private int _cardShakeVibrato;
        private float _cardShakeRandomness;
        private float _animationDelay;
        private float _glowImageRotateSpeed;
        private float _glowBackgroundImageRotateSpeed;

        private bool _canRotateGlowImage;
        private Tween _cardShakeTween;
        private bool _canShakeCard;

        public void StartCardAnim()
        {
            _canRotateGlowImage = true;
            _canShakeCard = true;
            _cardShakeTween.Kill();
            _cardShakeTween = null;
            cardParentTransform.localEulerAngles = Vector3.zero;
            DOVirtual.DelayedCall(_animationDelay, CardShake);
        }

        private void Update()
        {
            if(_canRotateGlowImage)
            {
                glowImageTransform.Rotate(0,0, _glowImageRotateSpeed * Time.deltaTime);
                glowBackgroundImageTransform.Rotate(0,0, _glowBackgroundImageRotateSpeed * Time.deltaTime);
            }
        }

        private void CardShake()
        {
            if (_canShakeCard == true)
                _cardShakeTween = cardParentTransform.DOShakeRotation(_cardShakeDuration, _cardShakeStrenght, _cardShakeVibrato, _cardShakeRandomness).OnComplete(StartCardAnim);
        }

        public void StopCardAnim()
        {
            if (_cardShakeTween != null)
            {
                _cardShakeTween.Kill();
                cardParentTransform.localEulerAngles = Vector3.zero;
                _canShakeCard = false;
                _canRotateGlowImage = false;
            }
        }

        public void SetDataFromSO(RewardPanelSO rewardPanelSO)
        {
            _cardShakeDuration = rewardPanelSO.cardShakeDuration;
            _cardShakeStrenght = rewardPanelSO.cardShakeStrenght;
            _cardShakeVibrato = rewardPanelSO.cardShakeVibrato;
            _cardShakeRandomness = rewardPanelSO.cardShakeRandomness;
            _animationDelay = rewardPanelSO.animationDelay;
            _glowImageRotateSpeed = rewardPanelSO.glowImageRotateSpeed;
            _glowBackgroundImageRotateSpeed = rewardPanelSO.glowBackgroundImageRotateSpeed;
        }
    }

}
