using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Code
{
    public class ControllerUi : MonoBehaviour 
    {
        public static ControllerUi instanse;

        [SerializeField] private TextMeshProUGUI _money;
        [SerializeField] private TextMeshProUGUI _inventorCount;
        [SerializeField] private RectTransform _coinCunter;
        [SerializeField] private Transform _cointCounterTransform;

        private List<bool> AnimationCutdown = new List<bool>();
        private bool isActiveAnimations;
        private bool isUpdateCounter;
        private void Awake()
        {
            if (instanse != null) Destroy(instanse);
            instanse = this;

            _cointCounterTransform = _coinCunter.transform;
          
        }
        private void Update()
        {
            if (AnimationCutdown.Count > 0 && !isActiveAnimations)
            {
                StartCoroutine(UpdateAnimation());
            }
        }

        public void UpdateMoneyText(int CurrentMoney)
        {
            _money.text = CurrentMoney.ToString();
            AnimationCutdown.Add(true);


            if (isUpdateCounter)
                StopCoroutine(UpdateEndTime());
            else
                StartCoroutine(UpdateEndTime());
           
        }

        IEnumerator UpdateAnimation()
        {
            isActiveAnimations = true;
            _coinCunter.gameObject.transform.DORotate(new Vector3(0, 0, 5), 0.1f, RotateMode.FastBeyond360);
            yield return new WaitForSeconds(0.1f);
            _coinCunter.gameObject.transform.DORotate(Vector3.zero, 0.1f, RotateMode.FastBeyond360);
            yield return new WaitForSeconds(0.1f);
            isActiveAnimations = false;

            if (AnimationCutdown.Count != 0)
                AnimationCutdown.RemoveAt(0);
        }

        IEnumerator UpdateEndTime()
        {
            isUpdateCounter = true;
            yield return new WaitForSeconds(0.5f);
            AnimationCutdown.Clear();
            //AnimationCutdown = new List<bool>();
            isUpdateCounter = false;
           
        }

        public void UpdateCountInventory(int InventoryCount, int MaxCountInventory)
        {
            _inventorCount.text = $"{InventoryCount} / {MaxCountInventory}";
        }
    }
}