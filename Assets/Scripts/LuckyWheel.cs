using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LuckyWheel : MonoBehaviour
{
    private LuckyWheelDataController wheelDataController;
    private LuckyWheelRotateController wheelRotateController;
    private LuckyWheelZoneController wheelZoneController;

    [Inject] private SceneChangeManager sceneManager;

    void Awake()
    {
        wheelDataController = GetComponent<LuckyWheelDataController>();
        wheelRotateController = GetComponent<LuckyWheelRotateController>();
        wheelZoneController = GetComponent<LuckyWheelZoneController>();
    }

    private void Start()
    {
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
        Debug.Log(wheelDataController.GetCurrentRewardItemSO().itemName + " " + wheelDataController.GetCurrentRewardItemAmount());
        sceneManager.OpenRewardScene(wheelDataController.GetCurrentRewardItemSO(),wheelDataController.GetCurrentRewardItemAmount());
    }

}
