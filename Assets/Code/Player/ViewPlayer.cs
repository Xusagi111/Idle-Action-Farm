using Assets.Code;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewPlayer : MonoBehaviour
{
    [SerializeField] private ControllerPLayer _controllerPlayer;
    [SerializeField] private ToolsPlayer _toolsPlayer;
    private bool isUpdateCutDown;
    private void Start()
    {
        InventoryPlayer.UpdateBlokCountInventory += TestMethods;
    }
    public void CutButton()
    {
        if (!_controllerPlayer.isStateAvailable)
            return;

        if (!_controllerPlayer.isCoolDown)
        {
            _controllerPlayer.CutDown();
            _toolsPlayer.UpdateCutDown();
            StartCoroutine(offCutDown());
        }
      
    }
    IEnumerator offCutDown()
    {
        yield return new WaitForSeconds(0.2f);
        _controllerPlayer.offCutDown();
    }
    private void TestMethods(int CountLenght)
    {
        ControllerUi.instanse.UpdateCountInventory(CountLenght, _controllerPlayer.InventoryPlayer.CountInventory);
    }
}
