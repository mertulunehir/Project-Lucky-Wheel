using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedReward : MonoBehaviour
{
    private CollectedRewardDataController dataController;
    // Start is called before the first frame update
    void Awake()
    {
        dataController = GetComponent<CollectedRewardDataController>();
    }

    public void SetCollectedRewardData(ItemSO collectedItemSO, int amount)
    {
        dataController.SetCollectedRewardData(collectedItemSO, amount);
    }

    public void UpdateCollectedItemAmount(int amount)
    {
        dataController.UpdateCollectedRewardData(amount);
    }
    public int GetCollectedItemAmount()
    {
        return dataController.GetItemAmount();
    }

    public ItemSO GetCollectedRewardItemSO()
    {
        return dataController.GetItemSO();
    }

}
