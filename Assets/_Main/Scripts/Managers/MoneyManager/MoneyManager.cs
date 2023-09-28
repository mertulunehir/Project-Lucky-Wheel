using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LWheel.MoneyManagerNameSpace
{
    public class MoneyManager : MonoBehaviour
    {
        [SerializeField] private MoneyManagerSO moneyManagerSO;
        private MoneyManagerCanvasController canvasController;
        private MoneyManagerDataController dataController;

        private void Awake()
        {
            canvasController = GetComponent<MoneyManagerCanvasController>();
            dataController = GetComponent<MoneyManagerDataController>();

            dataController.SetDataFromSO(moneyManagerSO);
        }

        private void Start()
        {
            canvasController.UpdateCashText(dataController.GetCashAmount());
            canvasController.UpdateGoldText(dataController.GetGoldAmount());
        }
        public void UpdateGold(int amount)
        {
            canvasController.UpdateGoldText(dataController.GetGoldAmount(), amount);
            dataController.UpdateGoldAmount(amount);
        }
        public void UpdateCash(int amount)
        {
            canvasController.UpdateCashText(dataController.GetCashAmount(), amount);
            dataController.UpdateCashAmount(amount);
        }

        public bool CanAffordBuyingWithCash(int amount)
        {
            if (amount <= dataController.GetCashAmount())
                return true;
            else
                return false;
        }
        public bool CanAffordBuyingWithGold(int amount)
        {
            if (amount <= dataController.GetGoldAmount())
                return true;
            else
                return false;
        }

        public void BuyWithCash(int amount)
        {
            dataController.UpdateCashAmount(-amount);
            canvasController.UpdateCashText(dataController.GetCashAmount());
        }

        public void BuyWithGold(int amount)
        {
            dataController.UpdateGoldAmount(-amount);
            canvasController.UpdateGoldText(dataController.GetGoldAmount());
        }
    }

}

