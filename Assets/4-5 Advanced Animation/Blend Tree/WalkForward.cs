using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WalkForward : MonoBehaviour
{
    [SerializeField] float _power = 1f;
    Rigidbody _rb = default;
    Animator _anim = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        _rb.AddForce(this.transform.forward * _power, ForceMode.Force);
    }

    void LateUpdate()
    {
        _anim.SetFloat("Speed", _rb.velocity.magnitude);
    }
}
