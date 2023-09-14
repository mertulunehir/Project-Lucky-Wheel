using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LuckyWheel : MonoBehaviour
{
    private LuckyWheelDataController wheelDataController;
    private LuckyWheelRotateController wheelRotateController;
    private LuckyWheelZoneController wheelZoneController;
    private LuckyWheelButtonController wheelButtonController;

    [Inject] private SceneChangeManager sceneManager;

    void Awake()
    {
        wheelDataController = GetComponent<LuckyWheelDataController>();
        wheelRotateController = GetComponent<LuckyWheelRotateController>();
        wheelZoneController = GetComponent<LuckyWheelZoneController>();
        wheelButtonController = GetComponent<LuckyWheelButtonController>();
    }

    private void Start()
    {
        ResetLuckyWheel();
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
        //wheelDataController.ChooseRewardAfterButtonClick();
        int currentRewardIndex = wheelDataController.GetCurrentRewardIndex();
        wheelRotateController.SetCurrentRewardIndex(currentRewardIndex);
        wheelRotateController.RotateLuckyWheel();
    }

    public void OpenRewardSceneAfterLuckyWheel()
    {
        sceneManager.OpenRewardScene(wheelDataController.GetCurrentRewardItemSO(),wheelDataController.GetCurrentRewardItemAmount());
    }

}
