using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    // プレイヤーのやられアニメーションのプレハブ
    public PlayerHit m_playerHitPrefab;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.name.Contains("Player"))
        {
            // プレイヤーからPlayerスクリプトを取得
            var player = other.GetComponent<Player>();

            // プレイヤーがやられたときに呼び出す関数を実行
            player.Dead();
        }
    }
}
