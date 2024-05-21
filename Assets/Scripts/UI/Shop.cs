using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopRegion;
    [SerializeField] private TurretAsset[] _turretAsset;

    [SerializeField] private Item _itemPrefab;

    [Inject] private Wallet _wallet;

    private void Start() {
        GenerateItems();
    }

    private void GenerateItems() {
        for (int i = 0; i < _turretAsset.Length; i++) {
            Item item = Instantiate(_itemPrefab, _shopRegion.transform);  
            item.SetItem(_turretAsset[i], _wallet);
        }
    }
}
