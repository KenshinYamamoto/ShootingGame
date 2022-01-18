using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// �X�R�A�̎���
// �EUI�̍쐬
// �EUI�̍X�V
// �E�G�ƒe�������������ɃX�R�A���Z+�X�V

// �Q�[���I�[�o�[�̎���
// �EUI���쐬
// �E�G��Player���Ԃ���������UI��\��
// �E���g���C�̎���
//  �ESpace����������V�[�����ēǂݍ���

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private void Awake()
    {
        instance = this;
    }

    public GameObject gameOverText;
    public Text scoreText;
    public GameObject gameClearText;
    public bool isClear;
    public GameObject backPanel;
    int score = 0;

    private void Start()
    {
        gameOverText.SetActive(false);
        gameClearText.SetActive(false);
        backPanel.SetActive(false);
        scoreText.text = "SCORE:" + score;
    }

    private void Update()
    {
        if (gameOverText.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Main");
        }
        else if(gameClearText.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            backPanel.SetActive(true);
        }
    }

    // �X�R�A���Z
    public void AddScore(int bonusPoint)
    {
        score += ParamsSO.Entity.addScore + bonusPoint;
        scoreText.text = "SCORE:" + score;
    }

    // �Q�[���I�[�o�[
    public void GameOver()
    {
        gameOverText.SetActive(true);
    }

    public void GameClear()
    {
        gameClearText.SetActive(true);
        isClear = true;
    }

    public void OnContinueButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnToTitleButton()
    {

    }
}
