using System;
using System.Collections;
using System.Collections.Generic;
using LWheel.RewardDatabase;
using UnityEngine;
using UnityEngine.UI;

namespace LWheel.LuckyWheelNameSpace
{

    public class LuckyWheelImageController : MonoBehaviour
    {
        [SerializeField]private Image indicatorImage;
        [SerializeField] private Image luckyWheelImage;

        private Sprite _bronzeLuckyWheelSprite;
        private Sprite _silverLuckyWheelSprite;
        private Sprite _goldLuckyWheelSprite;
        private Sprite _bronzeLuckyWheelIndicator;
        private Sprite _silverLuckyWheelIndicator;
        private Sprite _goldLuckyWheelIndicator;

        private LuckyWheelZones currentZone = LuckyWheelZones.Bronze;

        private int silverLuckyWheelRatio;
        private int goldLuckyWheelRatio;

        public void SetLuckyWheelImage(int zoneNumber)
        {

            if(zoneNumber % goldLuckyWheelRatio == 0)
            {
                if (!currentZone.Equals(LuckyWheelZones.Gold))
                {
                    currentZone = LuckyWheelZones.Gold;
                    luckyWheelImage.sprite = _goldLuckyWheelSprite;
                    indicatorImage.sprite = _goldLuckyWheelIndicator;
                }
            }
            else if (zoneNumber % silverLuckyWheelRatio == 0 )
            {
                if (!currentZone.Equals(LuckyWheelZones.Silver))
                {
                    currentZone = LuckyWheelZones.Silver;
                    luckyWheelImage.sprite = _silverLuckyWheelSprite;
                    indicatorImage.sprite = _silverLuckyWheelIndicator;
                }
            }
            else
            {
                if (!currentZone.Equals(LuckyWheelZones.Bronze))
                {
                    currentZone = LuckyWheelZones.Bronze;
                    luckyWheelImage.sprite = _bronzeLuckyWheelSprite;
                    indicatorImage.sprite = _bronzeLuckyWheelIndicator;
                }
            }
        }

        public void SetDataFromSO(LuckyWheelSO luckyWheelSO)
        {
            _bronzeLuckyWheelSprite = luckyWheelSO.bronzeLuckyWheelSprite;
            _silverLuckyWheelSprite = luckyWheelSO.silverLuckyWheelSprite;
            _goldLuckyWheelSprite = luckyWheelSO.goldLuckyWheelSprite;
            _bronzeLuckyWheelIndicator = luckyWheelSO.bronzeLuckyWheelIndicator;
            _silverLuckyWheelIndicator = luckyWheelSO.silverLuckyWheelIndicator;
            _goldLuckyWheelIndicator = luckyWheelSO.goldLuckyWheelIndicator;

            silverLuckyWheelRatio = luckyWheelSO.silverLuckyWheelRatio;
            goldLuckyWheelRatio = luckyWheelSO.goldLuckyWheelRatio;
        }
    }

    public enum LuckyWheelZones
    {
        Bronze,
        Silver,
        Gold
    }
}
