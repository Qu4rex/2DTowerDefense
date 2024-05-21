using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TextMoney : MonoBehaviour
{
    [SerializeField] private Text _moneyText;

    [Inject] private Wallet _wallet;

    private Animator _anim;

    private void OnEnable() => _wallet.onChangedMoney += UpdateMoney;
    private void OnDisable() => _wallet.onChangedMoney -= UpdateMoney;

    private void UpdateMoney() {
        _moneyText.text = _wallet.GetMoney.ToString();

        // _anim = _moneyText.GetComponent<Animator>();
    
        // if(_anim != null) {
        //     _anim.SetTrigger("coinEffect");
        // }
    }
}
