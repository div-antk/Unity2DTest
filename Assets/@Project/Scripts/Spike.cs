using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    // プレイヤーのやられアニメーションのプレハブ
    public PlayerHit m_playerHitPrefab;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Contains("Player"))
        {
            Destroy(other.gameObject);
        
            // シーンに存在するCameraShakerスクリプトを検索する
            var cameraShaker = FindObjectOfType<CameraShaker>();
            
            cameraShaker.Shake();
        
            // 2秒後にリトライする
            Invoke("onRetry", 2);

            // このプレイヤーのやられアニメーションのオブジェクトを生成
            Instantiate
            (
                m_playerHitPrefab,
                other.transform.position,
                Quaternion.identity
            );
        }
    }

    // リトライするたびに呼び出される関数
    private void onRetry()
    {
        // 現在のシーンを読み込み直してリトライする
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
