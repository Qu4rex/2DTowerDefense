using UnityEngine;
using UnityEngine.UI;

public class TextMoney : MonoBehaviour
{
    [SerializeField] private Text _moneyText;

    private Animator _anim;

    private void OnEnable() => Wallet.onChangedMoney += UpdateMoney;
    private void OnDisable() => Wallet.onChangedMoney -= UpdateMoney;

    private void UpdateMoney(int _value)
    {
        _moneyText.text = _value.ToString();
        _anim = _moneyText.GetComponent<Animator>();
        
        if(_anim != null) {
            _anim.SetTrigger("coinEffect");
        }
    }
}
