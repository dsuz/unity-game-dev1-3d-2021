using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerMovement : MonoBehaviour
{
    [SerializeField] CharacterControllerMoveMethod _moveMethod = CharacterControllerMoveMethod.Move;
    [SerializeField] float _speed = 3f;
    CharacterController _controller = default;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        dir = Camera.main.transform.TransformDirection(dir);
        dir.y = 0;

        switch (_moveMethod)
        {
            case CharacterControllerMoveMethod.Move:
                _controller.Move(dir.normalized * _speed * Time.deltaTime);

                //if (_controller.isGrounded)
                //{
                //    Debug.Log("接地しています");
                //}
                //else
                //{
                //    Debug.Log("接地していません");
                //}

                break;
            case CharacterControllerMoveMethod.SimpleMove:
                _controller.SimpleMove(dir.normalized * _speed);
                break;
            default:
                break;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log($"{hit.collider.name} に衝突した(OnControllerColliderHit)");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{collision.gameObject.name} に衝突した(OnCollisionEnter)");
    }
}

enum CharacterControllerMoveMethod
{
    Move,
    SimpleMove,
}
