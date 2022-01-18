using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PlayerShip������L�[�œ�����
// �E�����L�[�̓��͂��󂯎��
// �EPlayer�̈ʒu��ύX����

// �e��ł�
// �E�e�����
// �E�e�̓��������
// �E���˃|�C���g�����
// �E�{�^�����������Ƃ��ɒe�𐶐�����:Instantiate
public class PlayerShip : MonoBehaviour
{
    public Transform firePoint; // �e�𔭎˂���ʒu���擾����
    public GameObject bulletPrefab;

    // ��0.02�b��1����s�����
    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 nextPosition = transform.position + new Vector3(x, y, 0) * Time.deltaTime * ParamsSO.Entity.playerSpeed;
        // x:(-8,8), y:(-4,4)
        nextPosition = new Vector3(Mathf.Clamp(nextPosition.x, -8f, 8f), Mathf.Clamp(nextPosition.y, -4f, 4f), nextPosition.z); // Player�͈̔͐���
        transform.position = nextPosition;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !GameController.instance.isClear)
        {
            SoundManager.instance.PlaySE(SoundManager.SE.Shoot);
            Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            Boom();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("BossEnemy"))
        {
            Boom();
        }
        else
        {
            return;
        }
    }

    // �Ԃ��������̏���
    void Boom()
    {
        // �Q�[���N���A���Ă��Ȃ��ꍇ
        if (!GameController.instance.isClear)
        {
            GameController.instance.GameOver(); // �Q�[���I�[�o�[
            SoundManager.instance.PlaySE(SoundManager.SE.Boom); // ���j����炷
            EffectManager.effectManager.PlayEffect(transform);
            Destroy(gameObject); // PlayerShip��j�󂷂�
        }
    }
}
