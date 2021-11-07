using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShootingRobotMove : MonoBehaviour
{
    [SerializeField] float _movePower = 5f;
    Rigidbody _rb = default;
    Animator _anim = default;
    Vector3 _dir = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        _dir = Input.GetAxisRaw("Horizontal") * Vector3.right + Input.GetAxisRaw("Vertical") * Vector3.forward;

    }

    void FixedUpdate()
    {
        _rb.AddForce(_dir.normalized * _movePower);
    }

    void LateUpdate()
    {
        if (_dir != Vector3.zero)
        {
            this.transform.forward = _dir;
        }

        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (_anim)
        {
            _anim.SetFloat("Speed", forward.magnitude);
        }
    }
}
