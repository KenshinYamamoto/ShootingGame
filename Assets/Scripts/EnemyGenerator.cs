using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 生成する位置(X座標)をランダムにしたい
public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // 繰り返し関数を実行する
        InvokeRepeating("Spawn", 2f, 0.5f); // Spawn関数を,2秒後に,0.5秒刻みで実行する
    }

    // 生成する
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
