using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject mainMenu;
    public GameObject GameOverMenu;
    public TextMeshProUGUI gameOverScoreText;
    public TextMeshProUGUI gameOverHighScoreText;

    private bool _gameOver;
    private int _highScore;
   
    void Start()
    {
      scoreText.gameObject.SetActive(false);
      mainMenu.SetActive(true);
      GameOverMenu.SetActive(false);
      _gameOver = false;
      _highScore = PlayerPrefs.GetInt("Highscore", 0);  
    }

          
    void Update()
    {
       scoreText.text = GameManager.Score.ToString();

       if (!_gameOver && GameManager.GameOver)
       {
            _gameOver = true;
        scoreText.gameObject.SetActive(false);
            GameOverMenu.SetActive(true);
            if (GameManager.Score > _highScore)
            {
                _highScore = GameManager.Score;
                PlayerPrefs.SetInt("Highscore", _highScore);
            }
            gameOverScoreText.text = " High Score:" + _highScore;
            gameOverHighScoreText.text = " High Score:" + _highScore;
        }
        
    }
    public void StartGame()
    {
        mainMenu.SetActive(false);
        scoreText.gameObject.SetActive(true);
        GameManager.StartGame();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
