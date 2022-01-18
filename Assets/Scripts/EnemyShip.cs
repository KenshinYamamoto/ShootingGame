using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敵の移動:真下に移動する
// 敵を生成:生成工場をつくる
// 敵に弾が当たったら爆発する
// 敵とPlayerが当たったら爆発する

// 敵が弾を発射する
// ・弾をつくる
// ・弾の移動を実装する
// ・発射ポイントをつくる
// ・敵から弾を生成する

public class EnemyShip : MonoBehaviour
{
    public GameObject enemyBulletPrefab; // 敵の弾

    float offset;
    void Start()
    {
        // 揺れ方をランダムにする
        offset = Random.Range(0, 2 * Mathf.PI);
        InvokeRepeating("Shot", ParamsSO.Entity.enemyBulletShot, ParamsSO.Entity.enemyBulletTime);
    }

    void Update()
    {
        // Time.frameCountは、時間が経つにつれて値が大きくなっていくもの
        // offsetをタス事で
        transform.position -= new Vector3(Mathf.Cos(Time.frameCount * 0.01f + offset) * 0.01f, 3 * Time.deltaTime, 0); // 0.01を掛けている所は、値が小さいほど敵機の振れ幅が大きくなる

        if (transform.position.y < -5.8f)
        {
            Destroy(gameObject);
        }
    }

    void Shot()
    {
        Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
    }

    // 敵に弾が当たったら爆発する
    // 当たり判定の基礎知識
    // 当たり判定を行うには
    // ・両者にColliderがついている
    // ・どちらか一方にRigidbodyがついている

    //isTriggerにチェックを付けた場合はこれが呼ばれる
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collisionにぶつかった相手の情報が入っている
        if (collision.CompareTag("Player"))
        {
            EffectManager.effectManager.PlayEffect(collision.transform); // Playerが爆破されるエフェクト
            GameController.instance.GameOver(); // ゲームオーバー
        }
        else if(collision.CompareTag("Bullet"))
        {
            GameController.instance.AddScore(0); // スコア加算(引数はボスを倒したときに加算される分なので、0で良いです)
        }
        else
        {
            return;
        }
        DestroyPrefab(collision);
    }

    void DestroyPrefab(Collider2D collision)
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Boom);
        EffectManager.effectManager.PlayEffect(transform);
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
