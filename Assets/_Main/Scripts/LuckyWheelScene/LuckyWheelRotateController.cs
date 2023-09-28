using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace LWheel.LuckyWheelNameSpace
{
    public class LuckyWheelRotateController : MonoBehaviour
    {
        [SerializeField] private Transform wheelRotateParent;
        [SerializeField] private int baseRotateCount = 3;
        [SerializeField] private float rotateTime = 3;
        [SerializeField] private AnimationCurve customRotateEase;

        private LuckyWheel luckyWheel;

        private int currentRewardIndex;

        private void Start()
        {
            luckyWheel = GetComponent<LuckyWheel>();
        }
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
    }

}
