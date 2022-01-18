using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // ã‚É“®‚­
    void Update()
    {
        transform.position += new Vector3(0, ParamsSO.Entity.playerBulletSpeed, 0) * Time.deltaTime;

        if(transform.position.y > 5.3)
        {
            Destroy(gameObject);
        }
    }
}
