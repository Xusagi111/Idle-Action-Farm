using Assets.Code;
using Assets.Code.Player;
using System.Collections;
using UnityEngine;

public class ControllerPLayer : MonoBehaviour
{
    [field: SerializeField] public InventoryPlayer InventoryPlayer { get; private set; }
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private DataPLayer _dataPLayer;
    private bool SwitchingActiveParticle;
    public bool isStateAvailable { get; private set; }
    public bool isCoolDown{get;private set;}
 
    private void Awake()
    {
        InventoryPlayer = new InventoryPlayer(40);

        _dataPLayer.ToolsPlayer.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BlockWheat BlockWheat))
        {
            AddBlockPlayerInventory(BlockWheat);
        }

        if (other.TryGetComponent(out Stock Stock))
        {
            Stock.Sale(InventoryPlayer);
            Debug.Log(true);
        }

        if (other.TryGetComponent(out GardenBed type))
        {
            isStateAvailable = true;
            _dataPLayer.ToolsPlayer.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out GardenBed dfdf))
        {
            isStateAvailable = false;
            _dataPLayer.ToolsPlayer.gameObject.SetActive(false);
        }
    }

    private void AddBlockPlayerInventory(BlockWheat blockWheat)
    {
        bool isAddBlock = InventoryPlayer.AddBlockWheat(blockWheat);
        if (isAddBlock)
        {
            blockWheat.transform.SetParent(_dataPLayer.PlayerPositionInventory.transform);
            blockWheat.transform.position = _dataPLayer.PlayerPositionInventory.transform.position;
            blockWheat.transform.localRotation = Quaternion.Euler(0,0,0);
        }
    }

    public void CutDown()
    {
        StartCoroutine(Rollback());
 
        _playerAnimator.SetBool("isCutDown", true);
       
        if (SwitchingActiveParticle)
            StopCoroutine(FalseEffectCutDown());

        _dataPLayer.EffectCutDown.Stop();
        _dataPLayer.EffectCutDown.Play();
        StartCoroutine(FalseEffectCutDown());
    }
    private IEnumerator Rollback()
    {
        isCoolDown = true;
        yield return new WaitForSeconds(0.5f);
        isCoolDown = false;
    }
    public void offCutDown()
    {
        _playerAnimator.SetBool("isCutDown", false);
    }

    private IEnumerator FalseEffectCutDown()
    {
        _dataPLayer.EffectCutDown.gameObject.SetActive(true);
        SwitchingActiveParticle = true;

        yield return new WaitForSeconds(1f);
        _dataPLayer.EffectCutDown.gameObject.SetActive(false);
        SwitchingActiveParticle = false;
    }
}
