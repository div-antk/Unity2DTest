
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject m_playerHitPrefab;

    // ジャンプした時に再生する SE
    public AudioClip m_jumpClip;


    // シーンが開始する時に呼び出される関数
    private void Awake()
    {
        // プレイヤーの移動を制御するコンポーネントを取得する
        var motor = GetComponent<PlatformerMotor2D>();

        // ジャンプした時に呼び出されるイベントに関数を登録する
        motor.onJump += OnJump;
    }

    // ジャンプした時に呼び出される関数
    private void OnJump()
    {
        // ジャンプした時の SE を再生する
        var audioSource = FindObjectOfType<AudioSource>();
        audioSource.PlayOneShot( m_jumpClip );
    }

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

    private AudioClip m_jumpClip;

     private void Awake() {
        var motor = GetComponent<PrivateMoror2D>();

        motor.onJump += OnJump()     
    }

private void OnJump()
{
    var audioSource = FindObjectOfType<audioSource>();
    audioSource.PlayOnShot(m_playerHitPrefab);
}

    // リトライするたびに呼び出される関数
    private void onRetry()
    {
        // 現在のシーンを読み込み直してリトライする
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

