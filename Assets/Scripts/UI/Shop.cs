using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _shopRegion;
    [SerializeField] private TurretAsset[] _turretAsset;

    [SerializeField] private Item _itemPrefab;

    private void Start() {
        for (int i = 0; i < _turretAsset.Length; i++) {
            Item item = Instantiate(_itemPrefab, _shopRegion.transform);  
            item.CreateItem(_turretAsset[i]);
        }
    }
}
