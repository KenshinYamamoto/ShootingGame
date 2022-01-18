using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ParamsSO : ScriptableObject
{
    [Header("�G�𐶐�����X�p��(���b�����ɐ������邩�ǂ���)")]
    public float span;

    [Header("�Q�[���J�n����{�X���o�Ă���܂ł̎���")]
    public float encountBossTime;

    [Header("�Q�[���J�n����G���o�Ă���܂ł̎���")]
    public float encountenemyTime;

    [Header("�v���C���[�𑀍삷�鑬�x(�f�t�H���g:15)")]
    public float playerSpeed;

    [Header("�v���C���[�̒e�̑��x(�f�t�H���g:10)")]
    public float playerBulletSpeed;

    [Header("�G����������Ă��牽�b��ɒe��ł�(�f�t�H���g:1f)")]
    public float enemyBulletShot;

    [Header("���b�����ɓG���e�𔭎˂��邩(�f�t�H���g:1f)")]
    public float enemyBulletTime;

    [Header("�G���łe�������Ă��鑬�x(�f�t�H���g:8f)")]
    public float enemyBulletSpeed;

    [Header("���Z�����X�R�A(�f�t�H���g:100)")]
    public int addScore;

    //MyScriptableObject���ۑ����Ă���ꏊ�̃p�X
    public const string PATH = "ParamsSO";

    //MyScriptableObject�̎���
    private static ParamsSO _entity;
    public static ParamsSO Entity
    {
        get
        {
            //���A�N�Z�X���Ƀ��[�h����
            if (_entity == null)
            {
                _entity = Resources.Load<ParamsSO>(PATH);

                //���[�h�o���Ȃ������ꍇ�̓G���[���O��\��
                if (_entity == null)
                {
                    Debug.LogError(PATH + " not found");
                }
            }

            return _entity;
        }
    }
}
