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

        private float cardShakeDuration;
        private float cardShakeStrenght;
        private int cardShakeVibrato;
        private float cardShakeRandomness;
        private float animationDelay;
        private float glowImageRotateSpeed;
        private float glowBackgroundImageRotateSpeed;

        private bool canRotateGlowImage;
        private Tween cardShakeTween;
        private bool canShakeCard;

        public void StartCardAnim()
        {
            canRotateGlowImage = true;
            canShakeCard = true;
            cardShakeTween.Kill();
            cardShakeTween = null;
            cardParentTransform.localEulerAngles = Vector3.zero;
            DOVirtual.DelayedCall(animationDelay, CardShake);
        }

        private void Update()
        {
            if(canRotateGlowImage)
            {
                glowImageTransform.Rotate(0,0,glowImageRotateSpeed*Time.deltaTime);
                glowBackgroundImageTransform.Rotate(0,0, glowBackgroundImageRotateSpeed * Time.deltaTime);
            }
        }

        private void CardShake()
        {
            if (canShakeCard == true)
                cardShakeTween = cardParentTransform.DOShakeRotation(cardShakeDuration, cardShakeStrenght, cardShakeVibrato, cardShakeRandomness).OnComplete(StartCardAnim);
        }

        public void StopCardAnim()
        {
            if (cardShakeTween != null)
            {
                cardShakeTween.Kill();
                cardParentTransform.localEulerAngles = Vector3.zero;
                canShakeCard = false;
                canRotateGlowImage = false;
            }
        }

        public void SetDataFromSO(RewardPanelSO rewardPanelSO)
        {
            cardShakeDuration = rewardPanelSO.cardShakeDuration;
            cardShakeStrenght = rewardPanelSO.cardShakeStrenght;
            cardShakeVibrato = rewardPanelSO.cardShakeVibrato;
            cardShakeRandomness = rewardPanelSO.cardShakeRandomness;
            animationDelay = rewardPanelSO.animationDelay;
            glowImageRotateSpeed = rewardPanelSO.glowImageRotateSpeed;
            glowBackgroundImageRotateSpeed = rewardPanelSO.glowBackgroundImageRotateSpeed;
        }
    }

}
