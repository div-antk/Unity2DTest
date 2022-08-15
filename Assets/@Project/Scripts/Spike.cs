using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Contains("Player"))
        {
            Destroy(other.gameObject);
        
            // シーンに存在するCameraShakerスクリプトを検索する
            var cameraShaker = FindObjectOfType<CameraShaker>();
            
            cameraShaker.Shake();
        
            // 2秒後にリトライする
            Invoke("onRetry", 2);
        }
    }

    // リトライするたびに呼び出される関数
    private void onRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
