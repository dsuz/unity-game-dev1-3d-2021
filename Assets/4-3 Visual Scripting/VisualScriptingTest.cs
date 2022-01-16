using UnityEngine;

/// <summary>
/// プレイヤーを追いかける。別のスクリプト (Visual Scripting) から呼ばれることを前提としている。
/// </summary>
public class VisualScriptingTest : MonoBehaviour
{
    /// <summary>プレイヤーのオブジェクト</summary>
    GameObject _player = default;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    /// <summary>
    /// 自分とプレイヤーとの距離を返す
    /// </summary>
    /// <returns></returns>
    public float DistanceFromPlayer()
    {
        Vector3 playerPosition = default;

        if (_player)
        {
            playerPosition = _player.transform.position;
        }

        return Vector3.Distance(this.transform.position, playerPosition);
    }

    /// <summary>
    /// プレイヤーを追いかける
    /// </summary>
    /// <param name="speed">追いかける速度</param>
    public void FollowPlayer(float speed)
    {
        Vector3 dir = default;

        if (_player)
        {
            dir = _player.transform.position - this.transform.position;
        }

        this.transform.Translate(dir * speed);
    }
}
