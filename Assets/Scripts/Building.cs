using UnityEngine;

public class Building : MonoBehaviour
{
    private Slot _slot;

    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _itemInfo;

    private void OnEnable() {
        Slot.onSelected += SetSlot;
        Item.onBought += CreateTurret;
        ItemInfo.onDestroyed += DestroyTurret;
    }

    private void OnDisable() {
        Slot.onSelected -= SetSlot;
        Item.onBought -= CreateTurret;
        ItemInfo.onDestroyed -= DestroyTurret;
    }

    private void SetSlot(Slot slot, TurretAsset turret) {
        _slot = slot;
        if(slot.SlotState == SlotState.Empty) {
            _shop.SetActive(true);
        } else {
            _itemInfo.SetActive(true);
            _itemInfo.GetComponent<ItemInfo>().SetItemInfo(turret);
        }
    }

    private void CreateTurret(TurretAsset turretAsset) {
        if(_slot != null) {
            _slot.CreateTurret(turretAsset);
            _shop.SetActive(false);
            _slot = null;
        }
    }

    private void DestroyTurret() {
        if(_slot != null) {
            _slot.DestroyTurret();
            _itemInfo.gameObject.SetActive(false);
            _slot = null;
        }
    }
}