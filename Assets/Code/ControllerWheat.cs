using Assets.Code;
using System;
using System.Collections;
using UnityEngine;

public class ControllerWheat : MonoBehaviour
{
    private bool is—utDown { get; set; }
    private DateTime timerData { get; set; }
    [SerializeField] private GameObject Wheat;
    [SerializeField] private GameObject CutGrass;
    [SerializeField] private int DebugTimeSecond;
 
    public void UpdateState()
    {
        bool isCurentCollision = false;
        TimeSpan CurrentTimeLeft = timerData - DateTime.Now;

        if (CurrentTimeLeft.Seconds > 0)
        {
            isCurentCollision = true;
        }
        if (!isCurentCollision && !is—utDown)
        {
            is—utDown = true;
            timerData = DateTime.Now.AddSeconds(10);
            SetActiveCurrentGameObj(false, true);
            UpdateTime();
            CreateBlock();
        }      

    }

    private void SetActiveCurrentGameObj(bool isWheat, bool isCut)
    {
        Wheat.gameObject.SetActive(isWheat);
        CutGrass.gameObject.SetActive(isCut);
    }

    private void UpdateTime()
    {
        UpdateTimer();

        StartCoroutine(UpdateTime1(DebugTimeSecond));

    }
    private IEnumerator UpdateTime1(int time)
    {
        yield return new WaitForSeconds(1f);
        if (time > 0)
        {
            UpdateTimer();
            StartCoroutine(UpdateTime1(DebugTimeSecond));
        }
        else
        {
            SetActiveCurrentGameObj(true, false);
            is—utDown = false;
        }
    }
    private void CreateBlock()
    {
        BlockWheat BlockWheat = WheatPool.instanse.UnitComponent;
        BlockWheat.transform.parent =  this.transform;
        BlockWheat.transform.position = transform.position;
        
        BlockWheat.gameObject.SetActive(true);
        BlockWheat.GameParent = gameObject.name;
    }
    private void UpdateTimer()
    {
        var CurrentTime = timerData - DateTime.Now;
        DebugTimeSecond = CurrentTime.Seconds;
    }
}
