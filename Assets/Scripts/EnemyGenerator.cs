using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��������ʒu(X���W)�������_���ɂ�����
public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // �J��Ԃ��֐������s����
        InvokeRepeating("Spawn", 2f, 0.5f); // Spawn�֐���,2�b���,0.5�b���݂Ŏ��s����
    }

    // ��������
    void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8f,8f), transform.position.y,transform.position.z);
        Instantiate(enemyPrefab, spawnPosition, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
