using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _health = 5;
    //[SerializeField] private int _healthMax;

    public void TakeDamage(float damage) {
        if (damage > 0) {
            _health -= damage;
            if (_health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
