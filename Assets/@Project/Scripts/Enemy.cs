using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PC2D;

public class Enemy : MonoBehaviour
{
    // 敵の移動を制御するコンポーネント
    private PlatformerMotor2D m_motor;

    // 敵のスプライトを表示するコンポーネント
    private SpriteRenderer m_renderer;

    // 敵の当たり判定を管理するコンポーネント
    private BoxCollider2D m_collider;

    private void Awake()
    {
        // 敵の移動を制御するコンポーネントを取得する
        m_motor = GetComponent<PlatformerMotor2D>();

        // 最初は画像を左向きにする
        m_renderer.flipX = false;

        // 敵の当たり判定を管理するコンポーネントを取得する
        m_collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        // 現在の進行方向を取得する
        var dir = 0 < m_motor.normalizedXMovement
            ? Vector3.right
            : Vector3.left;

        // 進行方向にタイルマップが存在するかどうかを確認する
        var offset = m_collider.size.y * 0.5f;
        var hit = Physics2D.Raycast
        (
            transform.position - new Vector3(0, offset, 0),
            dir,
            m_collider.size.x * 0.55f,
            Globals.ENV_MASK
        );

        // 進行方向にタイルマップが存在する場合
        if (hit.collider != null)
        {
            // 移動方向を反転させる
            m_motor.normalizedXMovement = -m_motor.normalizedXMovement;

            // 画像の向きを反転させる
            m_renderer.flipX = !m_renderer.flipX;
        }
    }
}
