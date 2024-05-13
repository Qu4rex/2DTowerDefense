using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaussTurret : BaseTurret
{
    [SerializeField] private LineRenderer _laserRenderer;
    [SerializeField] private GameObject _laserEffect;

    [SerializeField] private float _fadeSpeed = 1f;
    [SerializeField] private float _startWidth = 1f;
    [SerializeField] private float _targetWidth = 0f;

    private bool _isShooted = false;

    public override void Shoot() {
        _laserRenderer.enabled = true;
        //_laserEffect.SetActive(true);

        _laserRenderer.SetPositions(new Vector3[] { _laserRenderer.transform.position, _target.position });
        //_laserEffect.transform.position = _target.position;

        _target.GetComponent<EnemyHealth>().TakeDamage(_damage);

        _laserRenderer.startWidth = _startWidth;
        _laserRenderer.endWidth = _startWidth;

        _isShooted = true;
    }

    private void Start() {
        StopAttack();
    }

    private void Update() {
        if(_isShooted)
            ReduceLine();   
    }

    private void StopAttack() {
        _laserRenderer.enabled = false;
        //_laserEffect.SetActive(false);
    }

    private void ReduceLine() {
        float currentWidth = _laserRenderer.startWidth;
        float newWidth = Mathf.MoveTowards(currentWidth, _targetWidth, _fadeSpeed * Time.deltaTime);

        _laserRenderer.startWidth = newWidth;
        _laserRenderer.endWidth = newWidth;

        if (newWidth <= _targetWidth)
        {
            StopAttack();
            _isShooted = false;
        }
    }
}
