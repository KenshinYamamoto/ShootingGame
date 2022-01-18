using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��������ʒu(X���W)�������_���ɂ�����
public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject bossEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // �J��Ԃ��֐������s����
        InvokeRepeating("Spawn", ParamsSO.Entity.encountenemyTime, ParamsSO.Entity.span); // Spawn�֐���,2�b���,0.5�b���݂Ŏ��s����
        Invoke("BossSpawn", ParamsSO.Entity.encountBossTime);
    }

    // ��������
    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8f,8f), transform.position.y,transform.position.z);
        Instantiate(enemyPrefab, spawnPosition, transform.rotation);
    }

    void BossSpawn()
    {
        Instantiate(bossEnemyPrefab, transform.position, transform.rotation);
        CancelInvoke();
    }
}
