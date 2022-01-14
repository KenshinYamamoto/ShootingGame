using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerShipを方向キーで動かす
// ・方向キーの入力を受け取る
// ・Playerの位置を変更する

// 弾を打つ
// ・弾を作る
// ・弾の動きを作る
// ・発射ポイントを作る
// ・ボタンを押したときに弾を生成する:Instantiate
public class PlayerShip : MonoBehaviour
{
    public Transform firePoint; // 弾を発射する位置を取得する
    public GameObject bulletPrefab;
    public Rigidbody2D rb2D;

    // 約0.02秒に1回実行される
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * 15f;
        // x:(-8,8), y:(-4,4)
        nextPosition = new Vector3(Mathf.Clamp(nextPosition.x, -8f, 8f), Mathf.Clamp(nextPosition.y, -4f, 4f), nextPosition.z); // Playerの範囲制御
        transform.position = nextPosition;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.PlaySE(SoundManager.SE.Shoot);
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        }
    }
}
