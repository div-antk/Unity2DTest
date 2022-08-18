using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // やられモーションの移動の速さ
    public Vector3 m_velocity = new Vector3(0, 15, 0);

    // やられアニメーションの移動にかかる重力の強さ
    public float m_graviry = 30;

    // Update is called once per frame
    void Update()
    {
        // やられアニメーションを移動
        transform.localPosition += m_velocity * Time.deltaTime;

        // 重力を適用してだんだん落下するようにする
        m_velocity.y -= m_graviry * Time.deltaTime;
    }
}
