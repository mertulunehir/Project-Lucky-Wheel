using System.Collections;
using System.Collections.Generic;
using LWheel.RewardDatabase;
using UnityEngine;

[CreateAssetMenu(fileName = "RewardsDatabase", menuName = "ScriptableObjects/RewardsDatabase", order = 3)]
public class RewardsDatabaseSO : ScriptableObject
{
    [Header("Rewards")]
    public List<Rewards> firstTierRewards = new List<Rewards>();
    public List<Rewards> secondTierRewards = new List<Rewards>();
    public List<Rewards> thirdTierRewards = new List<Rewards>();

    [Header("Bomb")]
    public Rewards bomb;

    [Header("Tier Start Zones")]
    public int secondTierStartZone;
    public int thirdTierStartZone;
}
