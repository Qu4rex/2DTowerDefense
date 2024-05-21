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

    private Wallet _wallet;
    
    public void SetItem(TurretAsset turretAsset, Wallet wallet) {
        _icon = turretAsset.Icon;
        _nameText.text = turretAsset.Name;
        _priceText.text = turretAsset.Price.ToString();
        _turretAsset = turretAsset;
        _wallet = wallet;

        _wallet.onChangedMoney += UpdateCondition;
        UpdateCondition();
    }

    private void Start() {
        _buyButton.onClick.AddListener(Buy);
    }

    private void Buy() {
        _wallet.DecreaseMoney(_turretAsset.Price);
        onBought?.Invoke(_turretAsset);
    }

    private void UpdateCondition() {
        if(_wallet.GetMoney >= _turretAsset.Price)
            _buyButton.interactable = true;
        else
            _buyButton.interactable = false;
    }
}
