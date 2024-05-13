using UnityEngine;

public class LaserTurret : BaseTurret
{
    [SerializeField] private LineRenderer _laserRenderer;
    [SerializeField] private GameObject _laserEffect;

    public override void Shoot() {
        _laserRenderer.enabled = true;
        //_laserEffect.SetActive(true);

        _laserRenderer.SetPositions(new Vector3[] { _laserRenderer.transform.position, _target.position });
        //_laserEffect.transform.position = _target.position;

        _target.GetComponent<EnemyHealth>().TakeDamage(_damage * Time.deltaTime);
    }

    private void Start() {
        StopAttack();
    }

    private void Update() {
        if(_target == null) {
            StopAttack();
        }
    }

    private void StopAttack() {
        _laserRenderer.enabled = false;
        //_laserEffect.SetActive(false);
    }
}