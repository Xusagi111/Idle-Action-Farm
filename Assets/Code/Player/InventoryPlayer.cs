using Assets.Code;
using System;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventoryPlayer
{
    public readonly int CountInventory;
    public static Action<int> UpdateBlokCountInventory;
    public InventoryPlayer(int CountInventory)
    {
        this.CountInventory = CountInventory;
        StackWheat = new List<BlockWheat>();
    }
    [field: SerializeField] private List<BlockWheat> StackWheat { get; set; }
  
    public bool AddBlockWheat(BlockWheat blockWheat)
    {
        if (CountInventory > StackWheat.Count && StackWheat.IndexOf(blockWheat) < 0)
        {
            StackWheat.Add(blockWheat);

            UpdateBlokCountInventory.Invoke(StackWheat.Count);

            return true;
        }
        return false;
    }

    public List<BlockWheat> GetStackeWhheat()
    {
        return StackWheat;
    }
    
    public void RemoveBlock(BlockWheat blockWheat)
    {
        StackWheat.Remove(blockWheat);
        UpdateBlokCountInventory.Invoke(StackWheat.Count);
    }
}
