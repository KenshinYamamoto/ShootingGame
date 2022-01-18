using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 8�����ɒe��ł�
// �E1�����ɒe��ł�
// �E�D���Ȋp�x�ɒe��ł�
// �E360�x��8�������Ēe�𔭎˂���

// ���Ԋu�Ŏ��s����
// �E�R���[�`���F���Ԃ̐��䂪�ȒP

// �G�̍s���𐧌䂷��
// �E�R���[�`��

// ����̈ʒu�܂ňړ�
// �EBoss�̐���
// �E����̈ʒu�܂ňړ�����
// �E�ړ����Ă���U��

public class BossEnemyShip : MonoBehaviour
{
    public BossEnemyBullet bulletPrefab;
    GameObject player;
    int hp = 10;

    void Start()
    {
        player = GameObject.Find("PlayerShip");
        StartCoroutine(CPU()); // (n,m),n�F��������,m�F���E�F�[�u��
    }
    IEnumerator CPU()
    {
        // ����̈ʒu���ゾ������
        while (transform.position.y > 3.3)
        {
            transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
            yield return null; // 1�t���[���҂�

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
            float angle = i * (2 * Mathf.PI / bulletCount); // �Ƃ肠����2PI(360�x)��bulletCount�������āAi���|�����i���������
            Shot(angle,speed);
        }
    }

    IEnumerator ShotNCurve(int bulletCount, float speed)
    {
        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (2 * Mathf.PI / bulletCount); // �Ƃ肠����2PI(360�x)��bulletCount�������āAi���|�����i���������
            Shot(angle - Mathf.PI/2f, speed);
            Shot(-angle - Mathf.PI / 2f, speed);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Shot(float angle, float speed)
    {
        BossEnemyBullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.Setting(angle, speed); // Mathf.PI/4f��45�x
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

    // Player��_��
    // �EPlayer�̈ʒu���擾
    // �E�ǂ̊p�x�ɑłĂ΂悢�̂��v�Z
    void PlayerAimShot(int bulletCount, float speed)
    {
        if(player != null)
        {
            // ��������݂�Player�̈ʒu���v�Z����
            Vector3 diffPosition = player.transform.position - transform.position;
            // �������猩��Player�̊p�x���o���F�X������p�x���o���B�A�[�N�^���W�F���g���g��
            float angleP = Mathf.Atan2(diffPosition.y, diffPosition.x);

            for (int i = 0; i < bulletCount; i++)
            {
                float angle = (i - bulletCount / 2f) * ((Mathf.PI / 2f) / bulletCount); // PI/2(90�x)��bulletCount�������āAi���|�����i���������
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
