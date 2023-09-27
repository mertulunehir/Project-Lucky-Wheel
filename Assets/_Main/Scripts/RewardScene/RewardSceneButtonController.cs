using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RewardSceneButtonController : MonoBehaviour
{
    [SerializeField]private Button giveUpButtonAfterReward, reviveButton, continueButton,giveUpButtonAfterBomb;

    [Inject] private PanelChangeManager panelManager;
    [Inject] private MoneyManager moneyManager;

    private const int reviveButtonPrice = 50;

    private void OnGiveUpButtonClickedAfterReward()
    {
        GetComponent<RewardScene>().GiveCollectedRewards();
        panelManager.OpenLuckyWheelPanelAfterGiveUp();
    }

    private void OnGiveUpButtonClickedAfterBomb()
    {
        GetComponent<RewardScene>().ClearCollectedRewards();
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
}
