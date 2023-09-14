using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class RewardSceneButtonController : MonoBehaviour
{
    [SerializeField]private Button giveUpButton, reviveButton, continueButton;


    [Inject] private SceneChangeManager sceneManager;
    [Inject] private MoneyManager moneyManager;

    private const int reviveButtonPrice = 50;


    private void OnGiveUpButtonClicked()
    {
        GetComponent<RewardScene>().GiveCollectedRewards();

        sceneManager.OpenLuckyWheelScene();

    }

    private void OnReviveButtonClicked()
    {
        sceneManager.OpenLuckyWheelScene();
        moneyManager.BuyWithGold(reviveButtonPrice);
    }

    private void OnContinueButtonClicked()
    {
        sceneManager.OpenLuckyWheelScene();
    }

    public void RewardCollectedButtonConfig()
    {
        giveUpButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        reviveButton.gameObject.SetActive(false);
    }

    public void BombCollectedButtonConfig()
    {
        //TODO : if give up button clicked give no reward restart all currentRewards
        //TODO : if revive buttonClicked give no reward but act like continue button
        //TODO : check if revive button price is lower than current gold amount

        giveUpButton.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);
        reviveButton.gameObject.SetActive(true);

        if (moneyManager.CanAffordBuyingWithGold(reviveButtonPrice))
            reviveButton.interactable = true;
        else
            reviveButton.interactable = false;
    }

    private void OnEnable()
    {
        giveUpButton.onClick.AddListener(OnGiveUpButtonClicked);
        reviveButton.onClick.AddListener(OnReviveButtonClicked);
        continueButton.onClick.AddListener(OnContinueButtonClicked);
    }
    private void OnDisable()
    {
        giveUpButton.onClick.RemoveListener(OnGiveUpButtonClicked);
        reviveButton.onClick.RemoveListener(OnReviveButtonClicked);
        continueButton.onClick.RemoveListener(OnContinueButtonClicked);
    }
}
