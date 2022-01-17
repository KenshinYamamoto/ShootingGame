using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �ݒ肳�ꂽ�����ɒe���ړ�������

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
        // 2PI��360�x
        // PI��180�x
        // PI/2��90�x
        dx = Mathf.Cos(angle) * speed;
        dy = Mathf.Sin(angle) * speed;
    }
}
