using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using Zenject;

namespace LWheel.LuckyWheelNameSpace
{
    public class LuckyWheelRotateController : MonoBehaviour
    {
        [SerializeField] private Transform wheelRotateParent;
        private int baseRotateCount;
        private float rotateTime;
        private AnimationCurve customRotateEase;
        [Inject]private LuckyWheel luckyWheel;
        private int currentRewardIndex;

        public void ResetWheelRotation()
        {
            wheelRotateParent.transform.eulerAngles = Vector3.zero;
        }

        public void SetCurrentRewardIndex(int index)
        {
            currentRewardIndex = index;
        }

        public void RotateLuckyWheel()
        {
            int offset = 45 * currentRewardIndex;
            wheelRotateParent.DOLocalRotate(new Vector3(0, 0, baseRotateCount * 360 + offset), rotateTime, RotateMode.LocalAxisAdd).SetEase(customRotateEase);
            DOVirtual.DelayedCall(rotateTime + 1f, OpenRewardScene);
        }

        private void OpenRewardScene()
        {
            luckyWheel.OpenRewardSceneAfterLuckyWheel();
        }

        public void SetDataFromSO(LuckyWheelSO luckyWheelSO)
        {
            baseRotateCount = luckyWheelSO.baseRotateCount;
            rotateTime = luckyWheelSO.rotateTime;
            customRotateEase = luckyWheelSO.customerRotateEase;
        }
    }

}
