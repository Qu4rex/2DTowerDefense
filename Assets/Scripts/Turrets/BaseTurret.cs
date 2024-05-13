using UnityEngine;
using UnityEditor;

public abstract class BaseTurret : MonoBehaviour
{
    [SerializeField] private Transform _turretRotationPoint;
    [SerializeField] private LayerMask _enemyMask;
    protected Transform _target;
    
    [SerializeField] private float _targetingRange = 3f;    
    private float _rotationSpeed = 300f;
    [SerializeField] protected float _damage = 1;

    [SerializeField] protected float _shootingRate;
    protected float _shootCooldown = 0.0f;

    protected bool CanAttack => _shootCooldown <= 0.0f;

    public abstract void Shoot();

    private void FixedUpdate() {
        if(_shootCooldown > 0)
            _shootCooldown -= Time.deltaTime;

        if(_target == null) {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if(!TargetIsInRange()) {
            _target = null;
        } else {
            if(CanAttack) {
                Shoot();
                _shootCooldown = _shootingRate;
            }
        }
    }

    private void FindTarget() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _targetingRange, (Vector2)transform.position, 0f, _enemyMask);

        if(hits.Length > 0) {
            _target = hits[0].transform;
        }
    }

    private void RotateTowardsTarget() {
        float angle = Mathf.Atan2(_target.position.y - transform.position.y, _target.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        _turretRotationPoint.rotation = Quaternion.RotateTowards(_turretRotationPoint.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    private bool TargetIsInRange() {
        return Vector2.Distance(_target.position, transform.position) <= _targetingRange;
    }

    private void OnDrawGizmosSelected() {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, _targetingRange);
    }
}