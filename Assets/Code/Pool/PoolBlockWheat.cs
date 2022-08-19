using Assets.Code;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBlockWheat : MonoBehaviour
{
    /*public static PoolBlockWheat instanse;

    List<BlockWheat> ListblockWheats;
    [SerializeField] private GameObject BlockWheats;
    [SerializeField] private int CountCreateBlocks;

    private void Awake()
    {
        if (instanse != null) Destroy(instanse);

        instanse = this; 
    }
    private void Start()
    {
        ListblockWheats = new List<BlockWheat>(CountCreateBlocks);
        CreateBlockWheat(CountCreateBlocks);
    }

    public BlockWheat BlockWheat
    {
        get
        {
            if (ListblockWheats.Count != 0)
            {
                BlockWheat GetBlock = ListblockWheats[0];
                ListblockWheats.Remove(GetBlock);
                return GetBlock;
            }
            else
            {
                CreateBlockWheat(5);
                BlockWheat GetBlock = ListblockWheats[0];
                ListblockWheats.Remove(GetBlock);
                return GetBlock;
            }
        }
        set
        {
            DisableGetWheat(value);
            ListblockWheats.Add(value);
            
        }
    }
    private void CreateBlockWheat(int CountCreate)
    {
        for (int i = 0; i < CountCreateBlocks; i++)
        {
            BlockWheat CreateBlock = Instantiate(BlockWheats, Vector3.one, Quaternion.identity, transform).GetComponent<BlockWheat>();
            CreateBlock.gameObject.SetActive(false);
            ListblockWheats.Add(CreateBlock);
        }
    }
    private void DisableGetWheat(BlockWheat blockWheat)
    {
        blockWheat.gameObject.SetActive(false);
        blockWheat.transform.SetParent(this.transform);
        blockWheat.gameObject.transform.position = Vector3.zero;
        blockWheat.gameObject.transform.localScale = Vector3.zero;
    }*/
}
