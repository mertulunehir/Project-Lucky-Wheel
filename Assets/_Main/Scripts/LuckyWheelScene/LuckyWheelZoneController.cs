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


        private int _currentZoneCount = 1;
        private int _currentTextZoneCount = 1;
        private int _maxZoneNumber;


        private int _startSpawnCount;
        private int _silverWheelRatio;
        private int _goldWheelRatio;
        private Color _bronzeColor;
        private Color _silverColor;
        private Color _goldColor;


        private void Start()
        {
            CreateStartZoneNumbers();
        }

        private void CreateStartZoneNumbers()
        {
            for (int i = 0; i < _startSpawnCount; i++)
            {
                GameObject zoneNumber = Instantiate(zoneNumberPrefab.gameObject, zoneNumberParent);
                zoneNumber.GetComponent<ZoneNumberUIController>().SetUIData(_currentTextZoneCount, GetLevelBackgroundColor(_currentTextZoneCount));
                _currentTextZoneCount++;
            }

        }

        private Color GetLevelBackgroundColor(int currentZoneCount)
        {
            if (currentZoneCount != 0)
            {
                if (currentZoneCount % _goldWheelRatio == 0)
                {
                    return _goldColor;
                }
                else if (currentZoneCount % _silverWheelRatio == 0)
                {
                    return _silverColor;
                }
                else
                    return _bronzeColor;
            }
            else
                return _bronzeColor;
            
        }


        private void MoveBar()
        {
            zoneNumberParent.DOLocalMoveX(zoneNumberParent.localPosition.x - 100, 0.7f).SetEase(Ease.InBounce);
        }

        public void ResetZoneNumber()
        {
            zoneNumberParent.localPosition = Vector3.zero;
            _currentZoneCount = 1;
            _currentTextZoneCount = 1+ _startSpawnCount;
        }

        public void UpdateZoneNumber()
        {

            if (_currentTextZoneCount > _maxZoneNumber)
            {
                GameObject zoneNumber = Instantiate(zoneNumberPrefab.gameObject, zoneNumberParent);
                zoneNumber.GetComponent<ZoneNumberUIController>().SetUIData(_currentTextZoneCount, GetLevelBackgroundColor(_currentTextZoneCount));
                _maxZoneNumber = _currentTextZoneCount;
            }
            _currentZoneCount++;
            _currentTextZoneCount++;
            DOVirtual.DelayedCall(0.2f, MoveBar);


        }

        public int GetZoneNumber()
        {
            return _currentZoneCount;
        }

        public void SetDataFromSO(LuckyWheelSO luckyWheelSO)
        {
            _startSpawnCount = luckyWheelSO.zoneBarStartSpawnCount;
            _silverWheelRatio = luckyWheelSO.silverLuckyWheelRatio;
            _goldWheelRatio = luckyWheelSO.goldLuckyWheelRatio;
            _bronzeColor = luckyWheelSO.zoneBarBackgroundBronzeColor;
            _silverColor = luckyWheelSO.zoneBarBackgroundSilverColor;
            _goldColor = luckyWheelSO.zoneBarBackgroundGoldColor;
        }
    }
}
