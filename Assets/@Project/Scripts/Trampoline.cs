using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    // プレイヤーをジャンプさせる高さ
    public float m_jumpHeight = 10;

    // 他のオブジェクトと当たったときに呼び出される関数
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 名前に Player が含まれるオブジェクトと当たったら
        if (other.name.Contains("Player"))
        {
            // プレイヤーの操作を制御するスクリプトを取得して
            var motor = other.GetComponent<PlatformerMotor2D>();

            // プレイヤーをジャンプさせる
            motor.ForceJump(m_jumpHeight);

            // トランポリンのアニメーターを取得
            var animator = GetComponent<Animator>();

            // ジャンプするときのアニメーションを再生
            animator.Play("Jump");
        }
    }
}
