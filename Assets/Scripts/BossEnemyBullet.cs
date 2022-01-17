using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Ý’è‚³‚ê‚½•ûŒü‚É’e‚ðˆÚ“®‚³‚¹‚é

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
        // 2PI‚ª360“x
        // PI‚ª180“x
        // PI/2‚ª90“x
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }
}
