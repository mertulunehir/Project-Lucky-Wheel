using System.Collections;
using System.Collections.Generic;
using LWheel.PanelChangeNameSpace;
using UnityEngine;
using Zenject;

namespace LWheel.LuckyWheelNameSpace
{

    public class LuckyWheel : MonoBehaviour
    {
        [SerializeField] private LuckyWheelSO luckyWheelSO;

        [Inject] private LuckyWheelDataController wheelDataController;
        [Inject] private LuckyWheelRotateController wheelRotateController;
        [Inject] private LuckyWheelZoneController wheelZoneController;
        [Inject] private LuckyWheelButtonController wheelButtonController;
        [Inject] private LuckyWheelImageController wheelImageController;

        [Inject] private PanelChangeManager panelManager;

        void Awake()
        {
            SetLuckyWheelData();
        }

        private void Start()
        {
            ResetLuckyWheel();
        }

        private void SetLuckyWheelData()
        {
            wheelDataController.SetDataFromSO(luckyWheelSO);
            wheelRotateController.SetDataFromSO(luckyWheelSO);
            wheelImageController.SetDataFromSO(luckyWheelSO);
            wheelZoneController.SetDataFromSO(luckyWheelSO);
            wheelButtonController.SetDataFromSO(luckyWheelSO);
        }



        public void ResetLuckyWheelAfterContinueButton()
        {
            wheelButtonController.EnableButton();
            wheelZoneController.UpdateZoneNumber();
            ResetLuckyWheel();
        }

        public void ResetLuckyWheelAfterGiveUp()
        {
            wheelButtonController.EnableButton();
            wheelZoneController.ResetZoneNumber();
            ResetLuckyWheel();
        }

        private void ResetLuckyWheel()
        {
            wheelRotateController.ResetWheelRotation();
            wheelDataController.GetWheelData(wheelZoneController.GetZoneNumber());
            wheelDataController.SetWheelElementData();
        }


        public void ChooseRewardAfterButtonClick()
        {
            int currentRewardIndex = wheelDataController.GetCurrentRewardIndex();
            wheelRotateController.SetCurrentRewardIndex(currentRewardIndex);
            wheelRotateController.RotateLuckyWheel();
        }

        public void OpenRewardSceneAfterLuckyWheel()
        {
            panelManager.OpenRewardPanel(wheelDataController.GetCurrentRewardItemSO(), wheelDataController.GetCurrentRewardItemAmount());
        }

    }
}
