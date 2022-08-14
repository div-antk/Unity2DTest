using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name.Contains("Player"))
        {
            Destroy(other.gameObject);
        
            // シーンに存在するCameraShakerスクリプトを検索する
            var cameraShaker = FindObjectOfType<CameraShaker>();
            
            cameraShaker.Shake();
        }
    }
}
