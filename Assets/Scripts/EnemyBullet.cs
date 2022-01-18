using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    void Update()
    {
        transform.position -= new Vector3(0, ParamsSO.Entity.enemyBulletSpeed, 0) * Time.deltaTime;

        if(transform.position.y < -5.3f)
        {
            Destroy(gameObject);
        }
    }
}
