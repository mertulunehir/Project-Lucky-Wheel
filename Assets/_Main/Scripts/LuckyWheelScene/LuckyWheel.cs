using System.Collections;
using System.Collections.Generic;
using LWheel.PanelChangeNameSpace;
using UnityEngine;
using Zenject;

namespace LWheel.LuckyWheelNameSpace
{

    public class LuckyWheel : MonoBehaviour
    {
        [SerializeField]private LuckyWheelSO luckyWheelSO;

        private LuckyWheelDataController wheelDataController;
        private LuckyWheelRotateController wheelRotateController;
        private LuckyWheelZoneController wheelZoneController;
        private LuckyWheelButtonController wheelButtonController;
        private LuckyWheelImageController wheelImageController;

        [Inject] private PanelChangeManager panelManager;

        void Awake()
        {
            wheelDataController = GetComponent<LuckyWheelDataController>();
            wheelRotateController = GetComponent<LuckyWheelRotateController>();
            wheelZoneController = GetComponent<LuckyWheelZoneController>();
            wheelButtonController = GetComponent<LuckyWheelButtonController>();
            wheelImageController = GetComponent<LuckyWheelImageController>();

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
