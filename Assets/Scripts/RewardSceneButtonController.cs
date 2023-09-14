using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RewardSceneButtonController : MonoBehaviour
{
    [SerializeField]private Button giveUpButtonAfterReward, reviveButton, continueButton,giveUpButtonAfterBomb;


    [Inject] private SceneChangeManager sceneManager;
    [Inject] private MoneyManager moneyManager;

    private const int reviveButtonPrice = 50;


    private void OnGiveUpButtonClickedAfterReward()
    {
        GetComponent<RewardScene>().GiveCollectedRewards();

        sceneManager.OpenLuckyWheelSceneAfterGiveUp();

    }

    private void OnGiveUpButtonClickedAfterBomb()
    {

        GetComponent<RewardScene>().ClearCollectedRewards();

        sceneManager.OpenLuckyWheelSceneAfterGiveUp();

    }

    private void OnReviveButtonClicked()
    {
        sceneManager.OpenLuckyWheelSceneAfterReward();
        moneyManager.BuyWithCash(reviveButtonPrice);
    }

    private void OnContinueButtonClicked()
    {
        sceneManager.OpenLuckyWheelSceneAfterReward();
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
        //TODO : if give up button clicked give no reward restart all currentRewards
        //TODO : if revive buttonClicked give no reward but act like continue button
        //TODO : check if revive button price is lower than current gold amount

        giveUpButtonAfterReward.gameObject.SetActive(false);
        giveUpButtonAfterBomb.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        reviveButton.gameObject.SetActive(true);

        if (moneyManager.CanAffordBuyingWithCash(reviveButtonPrice))
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
