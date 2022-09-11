using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject m_playerHitPrefab;

    // プレイヤーがやられたときに呼び出す関数
    public void Dead()
    {
        // プレイヤーを非表示にする
        // Destroy 関数でプレイヤーを削除してしまうと
        // OnRetry 関数が呼び出されなくなるため
        // SetActive 関数で非表示にする
        gameObject.SetActive(false);

        // シーンに存在するCameraShakerスクリプトを検索する
        var cameraShaker = FindObjectOfType<CameraShaker>();
        
        cameraShaker.Shake();
    
        // 2秒後にリトライする
        Invoke("onRetry", 2);

        // このプレイヤーのやられアニメーションのオブジェクトを生成
        Instantiate
        (
            m_playerHitPrefab,
            transform.position,
            Quaternion.identity
        );
    }

    // リトライするたびに呼び出される関数
    private void onRetry()
    {
        // 現在のシーンを読み込み直してリトライする
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
