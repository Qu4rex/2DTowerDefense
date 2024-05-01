using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _target;
    private int _damage;

    [SerializeField] private float _speed = 5f;

    private Rigidbody2D _rb;

    public void SetTarget(Transform target, int damage) {
        _target = target;
        _damage = damage;
    }

    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if(!_target) return;
        Vector2 direction = (_target.position - transform.position).normalized;

        _rb.velocity = direction * _speed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        other.gameObject.GetComponent<EnemyHealth>().TakeDamage(_damage);
        Destroy(gameObject);
    }
}
