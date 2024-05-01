using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "Turret", menuName = "TurretAsset")]
public class TurretAsset : ScriptableObject 
{
    public string Name;
    public Image Icon;
    public int Price;
    
    public GameObject TurretPrefab;
}
