using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "MoneyManager", menuName = "ScriptableObjects/MoneyManager", order = 5)]
public class MoneyManagerSO : ScriptableObject
{
    [Header("Money System Save Parameters")]
    public string cashSaveKey;
    public string goldSaveKey;
}
