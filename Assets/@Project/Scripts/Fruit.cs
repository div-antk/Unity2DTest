using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    //他のプロジェクトとぶつかったときに呼び出される関数
    private void OnTriggerEnter2D(Collider2D other)
    {
        //名前に "Player" が含まれるオブジェクトとぶつかったら
        if (other.name.Contains("Player"))
        {
            //自分自身を削除
            Destroy(gameObject);
        }
    }
}
