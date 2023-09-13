using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LuckyWheel : MonoBehaviour
{

    private int currentZoneNumber = 1;

    private LuckyWheelDataController wheelDataController;
    private LuckyWheelRotateController wheelRotateController;

    [Inject] private SceneChangeManager sceneManager;

    void Awake()
    {
        wheelDataController = GetComponent<LuckyWheelDataController>();
        wheelRotateController = GetComponent<LuckyWheelRotateController>();
    }

    private void Start()
    {
        wheelDataController.GetWheelData(currentZoneNumber);
        wheelDataController.SetWheelElementData();
    }

    public void ChooseRewardAfterButtonClick()
    {
        wheelDataController.ChooseRewardAfterButtonClick();
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
