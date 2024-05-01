using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _health = 5;

    //[SerializeField] private int _healthMax;

    public void TakeDamage(int damage) {
        if (damage > 0) {
            _health -= damage;
            if (_health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
