using System;
using UnityEngine;

namespace Assets.Code
{
    public class MoneyController : MonoBehaviour
    {
        public static MoneyController instanse;

        public Action<int> EventUpdateMoneyState;

        private MoneyData moneyData;
        private void Start()
        {
            EventUpdateMoneyState += UpdateMoney;
            if (instanse != null) Destroy(instanse);
            instanse = this;

            moneyData = new MoneyData();
        }
        private void OnDestroy()
        {
            EventUpdateMoneyState += UpdateMoney;
        }
        private void UpdateMoney(int Money)
        {
            moneyData.Money += Money;
            ControllerUi.instanse.UpdateMoneyText(moneyData.Money);
        }
    }
    public class MoneyData
    {
       public int Money { get; set; }
    }
}