using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "LuckyWheel", menuName = "ScriptableObjects/LuckyWheel", order = 2)]
public class LuckyWheelSO : ScriptableObject
{

    [Header("Rotate Parameters")]
    public int baseRotateCount;
    public float rotateTime;
    public AnimationCurve customerRotateEase;
    [Header("Zone Bar Parameters")]
    public int silverLuckyWheelRatio;
    public int goldLuckyWheelRatio;
    public int zoneBarStartSpawnCount;
    public Color zoneBarBackgroundBronzeColor;
    public Color zoneBarBackgroundSilverColor;
    public Color zoneBarBackgroundGoldColor;
    [Header("Lucky Wheel Image Database")]
    public Sprite bronzeLuckyWheelSprite;
    public Sprite silverLuckyWheelSprite;
    public Sprite goldLuckyWheelSprite;
    public Sprite bronzeLuckyWheelIndicator;
    public Sprite silverLuckyWheelIndicator;
    public Sprite goldLuckyWheelIndicator;

}
