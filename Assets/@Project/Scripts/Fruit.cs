using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    // 獲得演出のプレハブ
    public GameObject m_collectredPrefab;

    // 他のプロジェクトとぶつかったときに呼び出される関数
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 名前に "Player" が含まれるオブジェクトとぶつかったら
        if (other.name.Contains("Player"))
        {
            // 獲得演出のオブジェクトを作成する
            var collected = Instantiate
            (
                m_collectredPrefab,
                transform.position,
                Quaternion.identity
            );

            // 獲得演出のオブジェクトからアニメーターの情報を取得
            var animator = collected.GetComponent<Animator>();

            // 現在再生中のアニメーションの情報を取得
            var info = animator.GetCurrentAnimatorStateInfo(0);

            // 現在再生中のアニメーションの再生時間（秒）を取得
            var time = info.length;

            // アニメーションの再生が完了したら獲得演出を削除するように登録
            Destroy(collected, time);
            
            // 自分自身を削除
            Destroy(gameObject);
        }
    }
}
