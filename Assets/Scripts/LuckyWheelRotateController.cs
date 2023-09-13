using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LuckyWheelRotateController : MonoBehaviour
{
    [SerializeField] private Transform wheelRotateParent;
    private int currentRewardIndex;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetCurrentRewardIndex(int index)
    {
        currentRewardIndex = index;
    }

    public void RotateLuckyWheel()
    {
        int offset = 45 * currentRewardIndex;

    }
}
