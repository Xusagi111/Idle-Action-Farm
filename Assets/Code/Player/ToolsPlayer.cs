using System.Collections.Generic;
using UnityEngine;

public class ToolsPlayer : MonoBehaviour
{
    [field: SerializeField] List<ControllerWheat> ListTrigerBlock { get; set; } = new List<ControllerWheat>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ControllerWheat blockWheat))
        {
            ListTrigerBlock.Add(blockWheat);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ControllerWheat blockWheat))
        {
            ListTrigerBlock.Remove(blockWheat);
        }
    }
    public void UpdateCutDown()
    {
        for (int i = 0; i < ListTrigerBlock.Count; i++)
        {
            ListTrigerBlock[i].UpdateState();
        }
    }
}
