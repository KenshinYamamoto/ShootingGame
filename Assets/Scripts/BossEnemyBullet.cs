using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 設定された方向に弾を移動させる

public class BossEnemyBullet : MonoBehaviour
{
    float dx;
    float dy;

    void Update()
    {
        transform.position += new Vector3(dx, dy, 0) * Time.deltaTime;

        if (transform.position.x > 10f || transform.position.x < -10f || transform.position.y < -5.8f || transform.position.y > 5.8f)
        {
            Destroy(gameObject);
        }
    }

    public void Setting(float angle,float speed)
    {
        // 2PIが360度
        // PIが180度
        // PI/2が90度
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }
}
