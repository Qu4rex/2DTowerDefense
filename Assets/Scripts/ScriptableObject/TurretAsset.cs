using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret", menuName = "TurretAsset")]
public class TurretAsset : ScriptableObject 
{
    [SerializeField] private string _name;
    [SerializeField] private Image _icon;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _turretPrefab;

    public string Name => _name;
    public Image Icon => _icon;
    public int Price => _price;
    public GameObject TurretPrefab => _turretPrefab;
}
