using UnityEngine.UI;
using UnityEngine;
using System;

public class ItemInfo : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private Text _nameText;

    [SerializeField] private Button _destroyButton;

    public static Action onDestroyed;

    private void Start() {
        _destroyButton.onClick.AddListener(Destroy);
    }

    public void SetItemInfo(TurretAsset turretAsset) {
        _icon = turretAsset.Icon;
        _nameText.text = turretAsset.Name;
    }

    private void Destroy() {
        onDestroyed?.Invoke();
    }
}
