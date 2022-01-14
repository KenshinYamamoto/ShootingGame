using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// スコアの実装
// ・UIの作成
// ・UIの更新
// ・敵と弾が当たった時にスコア加算+更新

// ゲームオーバーの実装
// ・UIを作成
// ・敵とPlayerがぶつかった時にUIを表示
// ・リトライの実装
//  ・Spaceを押したらシーンを再読み込み

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject gameOverText;
    public Text scoreText;
    int score = 0;

    private void Start()
    {
        gameOverText.SetActive(false);
        scoreText.text = "SCORE:" + score;
    }

    private void Update()
    {
        if (gameOverText.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
    }

    // スコア加算
    public void AddScore()
    {
        score += 100;
        scoreText.text = "SCORE:" + score;
    }

    // ゲームオーバー
    public void GameOver()
    {
        gameOverText.SetActive(true);
    }
}
