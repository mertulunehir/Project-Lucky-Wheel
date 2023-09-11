using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRewardCanvasController : MonoBehaviour
{
    [SerializeField] private CurrentReward currentRewardPrefab;

    private List<CurrentReward> currentRewards;

    private void Start()
    {
        currentRewards = new List<CurrentReward>();
    }

    public void AddReward()
    {
        //TODO add reward. if reward already exist Update its value
    }
}
