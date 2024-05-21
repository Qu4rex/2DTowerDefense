using UnityEngine;
using System;

public class Wallet : MonoBehaviour
{
    [SerializeField] private int _money;

    public event Action onChangedMoney;

    public int GetMoney => _money;

    private void Start() {
        _money = PlayerPrefs.GetInt(KeySave.Money);
        onChangedMoney?.Invoke();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.P))
            IncreaseMoney(50); 
    }

    public void IncreaseMoney(int _value) {
        if(_value > 0) {
            _money += _value;
            PlayerPrefs.SetInt(KeySave.Money, _money);
        }
        onChangedMoney?.Invoke();
    }
    public void DecreaseMoney(int _value) {
        if(_value > 0) {
            _money -= _value;
            PlayerPrefs.SetInt(KeySave.Money, _money);
        }
        onChangedMoney?.Invoke();
    }
}
