using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 8方向に弾を打つ
// ・1方向に弾を打つ
// ・好きな角度に弾を打つ
// ・360度を8分割して弾を発射する

// 一定間隔で実行する
// ・コルーチン：時間の制御が簡単

// 敵の行動を制御する
// ・コルーチン

// 特定の位置まで移動
// ・Bossの生成
// ・特定の位置まで移動する
// ・移動してから攻撃

public class BossEnemyShip : MonoBehaviour
{
    public BossEnemyBullet bulletPrefab;
    GameObject player;
    int hp = 10;

    void Start()
    {
        player = GameObject.Find("PlayerShip");
        StartCoroutine(CPU()); // (n,m),n：何方向に,m：何ウェーブで
    }
    IEnumerator CPU()
    {
        // 特定の位置より上だったら
        while (transform.position.y > 3.3)
        {
            transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
            yield return null; // 1フレーム待つ

        }
        while (true)
        {
            yield return ShotNWaveM(8, 4);
            yield return new WaitForSeconds(1f);
            yield return ShotNWaveMCurve(17, 2);
            yield return new WaitForSeconds(1f);
            yield return WaveNPlayerAimShot(5, 4);
            yield return new WaitForSeconds(3f);
        }
    }


    void ShotN(int bulletCount,float speed)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // とりあえず2PI(360度)をbulletCount分割して、iを掛ければi等分される
            Shot(angle,speed);
        }
    }

    IEnumerator ShotNCurve(int bulletCount, float speed)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // とりあえず2PI(360度)をbulletCount分割して、iを掛ければi等分される
            Shot(angle - Mathf.PI/2f, speed);
            Shot(-angle - Mathf.PI / 2f, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Shot(float angle, float speed)
    {
        BossEnemyBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle, speed); // Mathf.PI/4fは45度
    }

    IEnumerator ShotNWaveM(int n,int m)
    {
        for (int w = 0; w < m; w++)
        {
            yield return new WaitForSeconds(0.3f);
            ShotN(n, 8f);
        }
    }

    IEnumerator ShotNWaveMCurve(int n, int m)
    {
        for (int w = 0; w < m; w++)
        {
            yield return new WaitForSeconds(0.3f);
            yield return ShotNCurve(n, 8f);
        }
    }

    // Playerを狙う
    // ・Playerの位置を取得
    // ・どの角度に打てばよいのか計算
    void PlayerAimShot(int bulletCount, float speed)
    {
        if(player != null)
        {
            // 自分からみたPlayerの位置を計算する
            Vector3 diffPosition = player.transform.position - transform.position;
            // 自分から見たPlayerの角度を出す：傾きから角度を出す。アークタンジェントを使う
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - bulletCount / 2f) * ((Mathf.PI / 2f) / bulletCount); // PI/2(90度)をbulletCount分割して、iを掛ければi等分される
                Shot(angleP + angle, speed);
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator WaveNPlayerAimShot(int n, int m)
    {
        for (int w = 0; w < m; w++)
        {
            yield return new WaitForSeconds(1f);
            PlayerAimShot(n, 8f);
        }
    }

    void DiscountHP()
    {
        hp--;
        if(hp <= 0)
        {
            Destroy(gameObject);
            EffectManager.effectManager.PlayBossEffect(transform);
            SoundManager.instance.PlaySE(SoundManager.SE.Boom);
            GameController.instance.GameClear();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            DiscountHP();
        }
    }
}
