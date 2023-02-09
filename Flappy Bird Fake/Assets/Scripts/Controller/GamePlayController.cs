using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController gamePlayController;

    [SerializeField]
    private Button _intructionButton;

    [SerializeField]
    private Text scoreText, endScoreText, bestScoreText;

    [SerializeField]
    private GameObject gameOverPanel, pausePanel;

    // Awake is called when the game first time run
    void Awake()
    {
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 0;
        MakeInstance();
    }
    void MakeInstance()
    {
        if(gamePlayController == null)
        {
            gamePlayController = this;
        }
    }

    // Update is called once per frame
    public void _IntructionButton()
    {
        Time.timeScale = 1;
        _intructionButton.gameObject.SetActive(false);
    }

    public void _SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void _SetEndScore(int endScore)
    {
        endScoreText.text = endScore.ToString();
    }

    public void _ShowPanel(int score)
    {
        gameOverPanel.SetActive(true);
        endScoreText.text = "" + score;
        if(score > GameManager.gameManager._GetHighScore())
        {
            GameManager.gameManager._SetHighScore(score);
        }
        bestScoreText.text = "" + GameManager.gameManager._GetHighScore();
    }

    public void _MenuButton ()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void _RestartButton()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void _PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void _ResumButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
