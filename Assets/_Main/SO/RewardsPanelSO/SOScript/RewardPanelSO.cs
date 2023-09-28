
using UnityEngine;

[CreateAssetMenu(fileName = "RewardPanel", menuName = "ScriptableObjects/RewardPanel", order = 4)]
public class RewardPanelSO : ScriptableObject
{
    [Header("Revive Button Price")]
    public int reviveButtonPrice;
    [Header("Information Texts")]
    public string winText;
    public string failText;
}
