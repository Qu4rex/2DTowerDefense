using UnityEngine;
using System;
using System.Collections;

public enum SlotState { Empty, Full }

public class Slot : MonoBehaviour
{
    [SerializeField] private Color _hovelColor;
    private Color _startColor;
    private SpriteRenderer _spriteRenderer;

    private static bool _isMouseEnabled = true;

    public static Action<Slot, TurretAsset> onSelected;

    private SlotState _slotState;
    public SlotState SlotState { get { return _slotState; } }

    private TurretAsset _turretAsset;
    private GameObject _turret;

    public void CreateTurret(TurretAsset turretAsset) {
        _turretAsset = turretAsset;
        _turret = Instantiate(turretAsset.TurretPrefab, transform.position, Quaternion.identity);
        _slotState = SlotState.Full;
        _isMouseEnabled = true;
        _spriteRenderer.color = _startColor; 
    }

    public void DestroyTurret() {
        Destroy(_turret);
        _slotState = SlotState.Empty;
        _isMouseEnabled = true;
        _spriteRenderer.color = _startColor;
    }

    private void Start() {
        _slotState = SlotState.Empty;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _startColor = _spriteRenderer.color;
    }

    private void OnMouseEnter() {
        if(_isMouseEnabled) {
            _spriteRenderer.color = _hovelColor;
        }
    }

    private void OnMouseExit() {
        if(_isMouseEnabled) {
           _spriteRenderer.color = _startColor; 
        }
    }

    private void OnMouseDown() {
        if(_isMouseEnabled) {
            _isMouseEnabled = false;
            onSelected?.Invoke(this, _turretAsset);
            Debug.Log("OnDown: " + _isMouseEnabled);
        }
    }
}
