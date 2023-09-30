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
        private int _baseRotateCount;
        private float _rotateTime;
        private AnimationCurve _customRotateEase;
        private int _currentRewardIndex;

        [Inject]private LuckyWheel luckyWheel;

        public void ResetWheelRotation()
        {
            wheelRotateParent.transform.eulerAngles = Vector3.zero;
        }

        public void SetCurrentRewardIndex(int index)
        {
            _currentRewardIndex = index;
        }

        public void RotateLuckyWheel()
        {
            int offset = 45 * _currentRewardIndex;
            wheelRotateParent.DOLocalRotate(new Vector3(0, 0, _baseRotateCount * 360 + offset), _rotateTime, RotateMode.LocalAxisAdd).SetEase(_customRotateEase);
            DOVirtual.DelayedCall(_rotateTime + 1f, OpenRewardScene);
        }

        private void OpenRewardScene()
        {
            luckyWheel.OpenRewardSceneAfterLuckyWheel();
        }

        public void SetDataFromSO(LuckyWheelSO luckyWheelSO)
        {
            _baseRotateCount = luckyWheelSO.baseRotateCount;
            _rotateTime = luckyWheelSO.rotateTime;
            _customRotateEase = luckyWheelSO.customerRotateEase;
        }
    }

}
