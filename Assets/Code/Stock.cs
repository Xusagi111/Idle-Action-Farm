using Assets.Code;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class Stock : MonoBehaviour
{
    [SerializeField] private int PriceMoney = 15;
    [SerializeField] private Transform PointMoveWheatBlock;
    [SerializeField] private Transform[] _pointMoveMoney = new Transform[2];
    private const float CountTimeMove = 0.5f;
    private List<BlockWheat> blockWheats;
    private InventoryPlayer InventoryPlayer;
    private const float DelayTime = 0.2f;
    public void Sale(InventoryPlayer inventoryPlayer)
    {
        ResetComponent();
        InventoryPlayer = inventoryPlayer;
        blockWheats = inventoryPlayer.GetStackeWhheat();
        MovmentElement(blockWheats);
    }

    private void MovmentElement(List<BlockWheat> AllblockWheats)
    {
        for (int i = 0; i < AllblockWheats.Count; i++)
        {
            MoveBlock(i, AllblockWheats[i]);
            MoveMoney(i);
        }
    }
    private void MoveBlock(int Item, BlockWheat blockWheat)
    {
        var DoMoveBlock = blockWheat.transform.DOMove(PointMoveWheatBlock.position, Item * 0.105f);
        DoMoveBlock.OnComplete(() => ResetBlocks(blockWheat));
    }

    private void MoveMoney(int item)
    {
        Component Money = MoneyPool.instanse.UnitComponent;
        Money.transform.position = new Vector3(_pointMoveMoney[0].transform.position.x + Random.Range(-2, 2f), _pointMoveMoney[0].transform.position.y + Random.Range(-2, 2f), _pointMoveMoney[0].transform.position.z); 
        Money.gameObject.SetActive(true);
        Money.transform.SetParent(_pointMoveMoney[0].transform);
        var DoMoveMoney = Money.transform.DOMove(_pointMoveMoney[1].transform.position, item * 0.105f + DelayTime);
        DoMoveMoney.OnComplete(() => ResetComponent(Money));
        Money.transform.DORotate(new Vector3(0, 360, 0), 3, RotateMode.FastBeyond360);
    }

    private void ResetComponent(Component Money)
    {
        MoneyPool.instanse.UnitComponent = Money;
        MoneyController.instanse.EventUpdateMoneyState(PriceMoney);
    }
    
    private void ResetBlocks(BlockWheat blockWheat)
    {
        InventoryPlayer.RemoveBlock(blockWheat);

        WheatPool.instanse.UnitComponent = blockWheat;
    }

    private void ResetComponent()
    {
        InventoryPlayer = null;
        blockWheats = null;
    }
}
