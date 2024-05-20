using UnityEngine;
using System;

public class Wallet : MonoBehaviour
{
    private static Wallet Instance;

    [SerializeField] private int _money;

    public static Action<int> onChangedMoney;

    public int GetMoney() => _money;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this.gameObject);
        } else {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start() {
        _money = PlayerPrefs.GetInt(KeySave.Money);
        UIUpdateMoney();
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
        UIUpdateMoney();
    }
    public void DecreaseMoney(int _value) {
        if(_value > 0) {
            _money -= _value;
            PlayerPrefs.SetInt(KeySave.Money, _money);
        }
        UIUpdateMoney();
    }

    public void UIUpdateMoney() {
        onChangedMoney?.Invoke(_money);
    }
}
