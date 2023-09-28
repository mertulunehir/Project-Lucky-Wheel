using System;
using System.Collections;
using System.Collections.Generic;
using LWheel.MoneyManagerNameSpace;
using LWheel.PanelChangeNameSpace;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;

namespace LWheel.RewardSceneNamespace
{

    public class RewardSceneButtonController : MonoBehaviour
    {
        [SerializeField] private Button giveUpButtonAfterReward;
        [SerializeField] private Button reviveButton;
        [SerializeField] private Button continueButton;
        [SerializeField] private Button giveUpButtonAfterBomb;
        [SerializeField] TMP_Text buttonCostText;

        [Inject] private PanelChangeManager panelManager;
        [Inject] private MoneyManager moneyManager;
        [Inject] private RewardScene rewardScene;

        private int reviveButtonPrice;

        private void OnGiveUpButtonClickedAfterReward()
        {
            rewardScene.GiveCollectedRewards();
            panelManager.OpenLuckyWheelPanelAfterGiveUp();
        }

        private void OnGiveUpButtonClickedAfterBomb()
        {
            rewardScene.ClearCollectedRewards();
            panelManager.OpenLuckyWheelPanelAfterGiveUp();
        }

        private void OnReviveButtonClicked()
        {
            moneyManager.BuyWithGold(reviveButtonPrice);
            panelManager.OpenLuckyWheelPanelAfterReward();
        }

        private void OnContinueButtonClicked()
        {
            panelManager.OpenLuckyWheelPanelAfterReward();
        }

        public void RewardCollectedButtonConfig()
        {
            giveUpButtonAfterReward.gameObject.SetActive(true);
            giveUpButtonAfterBomb.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(true);
            reviveButton.gameObject.SetActive(false);
        }

        public void BombCollectedButtonConfig()
        {
            giveUpButtonAfterReward.gameObject.SetActive(false);
            giveUpButtonAfterBomb.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(false);
            reviveButton.gameObject.SetActive(true);

            if (moneyManager.CanAffordBuyingWithGold(reviveButtonPrice))
                reviveButton.interactable = true;
            else
                reviveButton.interactable = false;
        }

        private void OnEnable()
        {
            giveUpButtonAfterReward.onClick.AddListener(OnGiveUpButtonClickedAfterReward);
            giveUpButtonAfterBomb.onClick.AddListener(OnGiveUpButtonClickedAfterBomb);
            reviveButton.onClick.AddListener(OnReviveButtonClicked);
            continueButton.onClick.AddListener(OnContinueButtonClicked);
        }
        private void OnDisable()
        {
            giveUpButtonAfterReward.onClick.RemoveListener(OnGiveUpButtonClickedAfterReward);
            giveUpButtonAfterBomb.onClick.RemoveListener(OnGiveUpButtonClickedAfterBomb);
            reviveButton.onClick.RemoveListener(OnReviveButtonClicked);
            continueButton.onClick.RemoveListener(OnContinueButtonClicked);
        }

        public void SetDataFromSO(RewardPanelSO panelSO)
        {
            reviveButtonPrice = panelSO.reviveButtonPrice;
            buttonCostText.text = reviveButtonPrice.ToString();
        }
    }
}
