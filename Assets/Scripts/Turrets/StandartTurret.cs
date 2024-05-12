using UnityEngine;

public class StandartTurret : BaseTurret
{
    [Header("Standart")]
    [SerializeField] private GameObject _bulletPrefab;

    public override void Shoot() {
        GameObject bulletObj = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(_target, _damage);
    }
}
