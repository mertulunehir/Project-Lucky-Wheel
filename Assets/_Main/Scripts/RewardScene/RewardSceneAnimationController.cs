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

        private float cardShakeDuration;
        private float cardShakeStrenght;
        private int cardShakeVibrato;
        private float cardShakeRandomness;
        private float animationDelay;

        private Tween cardShakeTween;
        private bool canShakeCard;

        public void StartCardAnim()
        {
            canShakeCard = true;
            cardShakeTween.Kill();
            cardShakeTween = null;
            cardParentTransform.localEulerAngles = Vector3.zero;
            DOVirtual.DelayedCall(animationDelay, CardShake);
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

            }
        }

        public void SetDataFromSO(RewardPanelSO rewardPanelSO)
        {
            cardShakeDuration = rewardPanelSO.cardShakeDuration;
            cardShakeStrenght = rewardPanelSO.cardShakeStrenght;
            cardShakeVibrato = rewardPanelSO.cardShakeVibrato;
            cardShakeRandomness = rewardPanelSO.cardShakeRandomness;
            animationDelay = rewardPanelSO.animationDelay;
        }
    }

}
