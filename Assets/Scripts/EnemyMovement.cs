using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int _speed;
    private int _pathIndex = 1;

    private Rigidbody2D _rb;
    private Transform _target;
    private Path _path;

    public void SetPath(Path path) {
        _path = path;
    }
    
    private void Start() {
        _rb = GetComponent<Rigidbody2D>();
        _target = _path.GetWaypointByIndex(_pathIndex);
    }

    private void Update() {
        if(Vector2.Distance(_target.position, transform.position) <= 0.1f) {
            _pathIndex++;

            if(_pathIndex == _path.GetWaypoints().Length) {
                Destroy(gameObject);
                return;
            } else {
                _target = _path.GetWaypointByIndex(_pathIndex);
            }
        }
    }

    private void FixedUpdate() {
        if (_target != null) {
            Vector2 direction = (_target.position - transform.position).normalized;
            _rb.velocity = direction * _speed;
        }
        
    }
}
