using UnityEngine.UI;
using UnityEngine;
using System;

public class Item : MonoBehaviour
{
    private TurretAsset _turretAsset;

    [SerializeField] private Image _icon;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _priceText;

    [SerializeField] private Button _buyButton;

    public static Action<TurretAsset> onBought;

    private void Start() {
        _buyButton.onClick.AddListener(Buy);
    }

    public void CreateItem(TurretAsset turretAsset) {
        _icon = turretAsset.Icon;
        _nameText.text = turretAsset.Name;
        _priceText.text = turretAsset.Price.ToString();
        _turretAsset = turretAsset;
    }

    private void Buy() {
        // HERE BUY SYSTEM
        onBought?.Invoke(_turretAsset);
    }
}
