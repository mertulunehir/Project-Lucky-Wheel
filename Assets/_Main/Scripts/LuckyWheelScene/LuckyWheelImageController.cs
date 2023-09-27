using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LWheel.LuckyWheelNameSpace
{

    public class LuckyWheelImageController : MonoBehaviour
    {
        public Image indicatorImage, luckyWheelImage;

        public Sprite bronzeLuckyWheelSprite, silverLuckyWheelSprite, goldLuckyWheelSprite;
        public Sprite bronzeLuckyWheelIndicator, silverLuckyWheelIndicator, goldLuckyWheelIndicator;

        private LuckyWheelZones currentZone = LuckyWheelZones.Bronze;

        private const int silverLuckyWheelNumber = 5;
        private const int goldLuckyWheelNumber = 30;

        public void SetLuckyWheelImage(int zoneNumber)
        {
            if (zoneNumber < silverLuckyWheelNumber)
            {
                if (!currentZone.Equals(LuckyWheelZones.Bronze))
                {
                    currentZone = LuckyWheelZones.Bronze;
                    luckyWheelImage.sprite = bronzeLuckyWheelSprite;
                    indicatorImage.sprite = bronzeLuckyWheelIndicator;
                }
            }
            else if (zoneNumber < goldLuckyWheelNumber)
            {
                if (!currentZone.Equals(LuckyWheelZones.Silver))
                {
                    currentZone = LuckyWheelZones.Silver;
                    luckyWheelImage.sprite = silverLuckyWheelSprite;
                    indicatorImage.sprite = silverLuckyWheelIndicator;
                }
            }
            else if (zoneNumber >= goldLuckyWheelNumber)
            {
                if (!currentZone.Equals(LuckyWheelZones.Gold))
                {
                    currentZone = LuckyWheelZones.Gold;
                    luckyWheelImage.sprite = goldLuckyWheelSprite;
                    indicatorImage.sprite = goldLuckyWheelIndicator;
                }
            }
        }
    }

    public enum LuckyWheelZones
    {
        Bronze,
        Silver,
        Gold
    }
}
