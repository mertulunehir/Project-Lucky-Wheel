using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using DG.Tweening;

namespace LWheel.LuckyWheelNameSpace
{

    public class LuckyWheelZoneController : MonoBehaviour
    {
        [SerializeField] private RectTransform zoneNumberParent;
        [SerializeField] private ZoneNumberUIController zoneNumberPrefab;


        private int currentZoneCount = 1;
        private int currentTextZoneCount = 1;
        private int maxZoneNumber;


        private int startSpawnCount;
        private int silverWheelRatio;
        private int goldWheelRatio;
        private Color bronzeColor;
        private Color silverColor;
        private Color goldColor;


        private void Start()
        {
            CreateStartZoneNumbers();
        }

        private void CreateStartZoneNumbers()
        {
            for (int i = 0; i < startSpawnCount; i++)
            {
                GameObject zoneNumber = Instantiate(zoneNumberPrefab.gameObject, zoneNumberParent);
                zoneNumber.GetComponent<ZoneNumberUIController>().SetUIData(currentTextZoneCount, GetLevelBackgroundColor(currentTextZoneCount));
                currentTextZoneCount++;
            }

        }

        private Color GetLevelBackgroundColor(int currentZoneCount)
        {
            if (currentZoneCount != 0)
            {
                if (currentZoneCount % goldWheelRatio == 0)
                {
                    return goldColor;
                }
                else if (currentZoneCount % silverWheelRatio == 0)
                {
                    return silverColor;
                }
                else
                    return bronzeColor;
            }
            else
                return bronzeColor;
            
        }


        private void MoveBar()
        {
            zoneNumberParent.DOLocalMoveX(zoneNumberParent.localPosition.x - 100, 0.7f).SetEase(Ease.InBounce);
        }

        public void ResetZoneNumber()
        {
            zoneNumberParent.localPosition = Vector3.zero;
            currentZoneCount = 1;
            currentTextZoneCount = 1+startSpawnCount;
        }

        public void UpdateZoneNumber()
        {

            if (currentTextZoneCount > maxZoneNumber)
            {
                GameObject zoneNumber = Instantiate(zoneNumberPrefab.gameObject, zoneNumberParent);
                zoneNumber.GetComponent<ZoneNumberUIController>().SetUIData(currentTextZoneCount, GetLevelBackgroundColor(currentTextZoneCount));
                maxZoneNumber = currentTextZoneCount;
            }
            currentZoneCount++;
            currentTextZoneCount++;
            DOVirtual.DelayedCall(0.2f, MoveBar);


        }

        public int GetZoneNumber()
        {
            return currentZoneCount;
        }

        public void SetDataFromSO(LuckyWheelSO luckyWheelSO)
        {
            startSpawnCount = luckyWheelSO.zoneBarStartSpawnCount;
            silverWheelRatio = luckyWheelSO.silverLuckyWheelRatio;
            goldWheelRatio = luckyWheelSO.goldLuckyWheelRatio;
             bronzeColor= luckyWheelSO.zoneBarBackgroundBronzeColor;
            silverColor = luckyWheelSO.zoneBarBackgroundSilverColor;
            goldColor = luckyWheelSO.zoneBarBackgroundGoldColor;
        }
    }
}
