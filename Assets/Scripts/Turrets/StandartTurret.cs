using UnityEngine;

public class StandartTurret : BaseTurret
{
    [SerializeField] private GameObject _bulletPrefab;

    [SerializeField] private Transform _shotPoint;

    public override void Shoot() {
        GameObject bulletObj = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(_target, _damage);
    }
}
