using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallPlatform : MonoBehaviour
{
    // 落ちる速さ
    public float m_speed = 0.3f;

    // プレイヤーが上に乗ったかどうか
    private bool m_isHit;

    private void Awake()
    {
        // 自分自身の MovingPlatformMotor2D を取得
        var motor = GetComponent<MovingPlatformMotor2D>();

        // プレイヤーが当たった際に呼び出されるイベントに関数を登録
        motor.onPlatformerMotorContact += OnContact;
    }

    // プレイヤーが当たった際に呼び出される関数
    private void OnContact(PlatformerMotor2D player)
    {
        // プレイヤーが落下中の場合
        if (player.IsFalling())
        {
            // プレイヤーが上に乗ったことにする
            m_isHit = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーが上に載った場合
        if (m_isHit)
        {
        // 自分自身の MovingPlatformMotor2D を取得
        var motor = GetComponent<MovingPlatformMotor2D>();

        // 落下させる
        motor.velocity = Physics2D.gravity * m_speed;
        }
    }
}
