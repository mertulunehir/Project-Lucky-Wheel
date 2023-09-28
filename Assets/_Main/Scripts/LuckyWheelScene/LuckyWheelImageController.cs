using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LWheel.LuckyWheelNameSpace
{

    public class LuckyWheelImageController : MonoBehaviour
    {
        public Image indicatorImage, luckyWheelImage;

        private Sprite bronzeLuckyWheelSprite;
        private Sprite silverLuckyWheelSprite;
        private Sprite goldLuckyWheelSprite;
        private Sprite bronzeLuckyWheelIndicator;
        private Sprite silverLuckyWheelIndicator;
        private Sprite goldLuckyWheelIndicator;

        private LuckyWheelZones currentZone = LuckyWheelZones.Bronze;

        private int silverLuckyWheelRatio;
        private int goldLuckyWheelRatio;

        public void SetLuckyWheelImage(int zoneNumber)
        {
            if (zoneNumber < silverLuckyWheelRatio)
            {
                if (!currentZone.Equals(LuckyWheelZones.Bronze))
                {
                    currentZone = LuckyWheelZones.Bronze;
                    luckyWheelImage.sprite = bronzeLuckyWheelSprite;
                    indicatorImage.sprite = bronzeLuckyWheelIndicator;
                }
            }
            else if (zoneNumber < goldLuckyWheelRatio)
            {
                if (!currentZone.Equals(LuckyWheelZones.Silver))
                {
                    currentZone = LuckyWheelZones.Silver;
                    luckyWheelImage.sprite = silverLuckyWheelSprite;
                    indicatorImage.sprite = silverLuckyWheelIndicator;
                }
            }
            else if (zoneNumber >= goldLuckyWheelRatio)
            {
                if (!currentZone.Equals(LuckyWheelZones.Gold))
                {
                    currentZone = LuckyWheelZones.Gold;
                    luckyWheelImage.sprite = goldLuckyWheelSprite;
                    indicatorImage.sprite = goldLuckyWheelIndicator;
                }
            }
        }

        public void SetDataFromSO(LuckyWheelSO luckyWheelSO)
        {
            bronzeLuckyWheelSprite = luckyWheelSO.bronzeLuckyWheelSprite;
            silverLuckyWheelSprite = luckyWheelSO.silverLuckyWheelSprite;
            goldLuckyWheelSprite = luckyWheelSO.goldLuckyWheelSprite;
            bronzeLuckyWheelIndicator = luckyWheelSO.bronzeLuckyWheelIndicator;
            silverLuckyWheelIndicator = luckyWheelSO.silverLuckyWheelIndicator;
            goldLuckyWheelIndicator = luckyWheelSO.goldLuckyWheelIndicator;

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
