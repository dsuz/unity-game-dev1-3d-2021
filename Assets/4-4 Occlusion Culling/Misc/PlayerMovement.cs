using UnityEngine;

/// <summary>
/// Rigidbody を使ってプレイヤーを動かすコンポーネント
/// 入力を受け取り、それに従ってオブジェクトを動かす
/// Shift キーを押しながら動かすことで「走る」ことができる
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    /// <summary>動く速さ（通常）</summary>
    [SerializeField] float _moveSpeed = 7f;
    /// <summary>動く速さ（ゆっくり）</summary>
    [SerializeField] float _creepSpeed = 3f;
    Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 方向の入力を取得し、方向を求める
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        // 入力方向のベクトルを組み立てる
        Vector3 dir = Vector3.forward * v + Vector3.right * h;
        float speed = Input.GetButton("Fire3") ? _creepSpeed : _moveSpeed;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            _rb.velocity = new Vector3(0f, _rb.velocity.y, 0f);
        }
        else
        {
            // カメラを基準に入力が上下=奥/手前, 左右=左右にキャラクターを向ける
            dir = Camera.main.transform.TransformDirection(dir);    // メインカメラを基準に入力方向のベクトルを変換する
            dir.y = 0;  // y 軸方向はゼロにして水平方向のベクトルにする
            this.transform.forward = dir;   // そのベクトルの方向にオブジェクトを向ける

            // 前方に移動する。ジャンプした時の y 軸方向の速度は保持する。
            Vector3 velo = this.transform.forward * speed;
            velo.y = _rb.velocity.y;
            _rb.velocity = velo;
        }
    }
}