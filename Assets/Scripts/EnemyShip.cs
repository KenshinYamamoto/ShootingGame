using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �G�̈ړ�:�^���Ɉړ�����
// �G�𐶐�:�����H�������
// �G�ɒe�����������甚������
// �G��Player�����������甚������

// �G���e�𔭎˂���
// �E�e������
// �E�e�̈ړ�����������
// �E���˃|�C���g������
// �E�G����e�𐶐�����

public class EnemyShip : MonoBehaviour
{
    public GameObject explosion; // �j��G�t�F�N�g��Prefab;
    public GameObject enemyBulletPrefab; // �G�̒e

    float offset;
    void Start()
    {
        // �h����������_���ɂ���
        offset = Random.Range(0, 2 * Mathf.PI);
        InvokeRepeating("Shot", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        // Time.frameCount�́A���Ԃ��o�ɂ�Ēl���傫���Ȃ��Ă�������
        // offset���^�X����
        transform.position -= new Vector3(Mathf.Cos(Time.frameCount * 0.01f + offset) * 0.01f, 3 * Time.deltaTime, 0); // 0.01���|���Ă��鏊�́A�l���������قǓG�@�̐U�ꕝ���傫���Ȃ�

        if (transform.position.y < -5.8f)
        {
            Destroy(gameObject);
        }
    }

    void Shot()
    {
        //SoundManager.instance.PlaySE(SoundManager.SE.Shoot);
        Instantiate(enemyBulletPrefab, transform.position, transform.rotation);
    }

    // �G�ɒe�����������甚������
    // �����蔻��̊�b�m��
    // �����蔻����s���ɂ�
    // �E���҂�Collider�����Ă���
    // �E�ǂ��炩�����Rigidbody�����Ă���

    //isTrigger�Ƀ`�F�b�N��t�����ꍇ�͂��ꂪ�Ă΂��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // collision�ɂԂ���������̏�񂪓����Ă���
        if (collision.CompareTag("Player"))
        {
            Instantiate(explosion, collision.transform.position, collision.transform.rotation); // Player�����j�����G�t�F�N�g
            GameController.instance.GameOver(); // �Q�[���I�[�o�[
        }
        else if(collision.CompareTag("Bullet"))
        {
            GameController.instance.AddScore(); // �X�R�A���Z
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
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(collision.gameObject);
    }
}
