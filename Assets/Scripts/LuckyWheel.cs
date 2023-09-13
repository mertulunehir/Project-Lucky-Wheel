using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyWheel : MonoBehaviour
{

    private int currentZoneNumber = 1;

    private LuckyWheelDataController wheelDataController;
    private LuckyWheelRotateController wheelRotateController;


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

}
