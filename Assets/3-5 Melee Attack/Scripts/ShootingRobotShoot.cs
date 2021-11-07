using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRobotShoot : MonoBehaviour
{
    [SerializeField] Transform _muzzle = default;
    [SerializeField] LineRenderer _line = default;
    [SerializeField] float _lineLength = 5f;
    [SerializeField] float _flashInterval = 0.05f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShootRoutine());
        }
    }

    IEnumerator ShootRoutine()
    {
        _line.SetPosition(0, _muzzle.position);
        Vector3 lineTarget = _muzzle.position + this.transform.forward * _lineLength;
        _line.SetPosition(1, lineTarget);
        yield return new WaitForSeconds(_flashInterval);
        _line.SetPosition(1, _line.GetPosition(0));
    }
}
