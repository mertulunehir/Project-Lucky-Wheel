using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScene : MonoBehaviour
{
    private RewardSceneDataController rewardSceneDataController;
    private RewardSceneButtonController rewardSceneButtonController;


    // Start is called before the first frame update
    void Start()
    {
        rewardSceneDataController = GetComponent<RewardSceneDataController>();
        rewardSceneButtonController = GetComponent<RewardSceneButtonController>();
    }

    public void SetRewardSceneData(ItemSO currentRewardSO,int amount)
    {
        rewardSceneDataController.SetRewardSceneData(currentRewardSO,amount);
    }

    public void ButtonRewardConfig()
    {
        rewardSceneButtonController.RewardCollectedButtonConfig();
    }

    public void ButtonBombConfig()
    {
        rewardSceneButtonController.BombCollectedButtonConfig();

    }
}
