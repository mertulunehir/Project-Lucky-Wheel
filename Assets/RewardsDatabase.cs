using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsDatabase : MonoBehaviour
{
    public List<Rewards> firstTierRewards = new List<Rewards>();
    public List<Rewards> secondTierRewards = new List<Rewards>();
    public List<Rewards> thirdTierRewards = new List<Rewards>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[Serializable]
public class Rewards
{
    public ItemSO itemSO;
    public int minRewardAmount;
    public int maxRewardAmount;
}
