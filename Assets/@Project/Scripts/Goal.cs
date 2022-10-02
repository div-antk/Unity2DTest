using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // ゴールしたかどうか
    private bool m_isGoal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!m_isGoal)
        {
            if (other.name.Contains("Player"))
            {
                var cameraShake = FindObjectOfType<CameraShaker>();

                cameraShake.Shake();

                m_isGoal = true;
            
                // ゴールのアニメーターを取得
                var animator = GetComponent<Animator>();

                animator.Play("Pressed");
            }
        }
    }

}
