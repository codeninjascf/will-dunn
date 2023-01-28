using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro
using Unity GameManager

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public GameObject mainMenu;
    public GameObject GameOverMenu;
    public TextMeshProUGUI GameOverScore;
    public TextMeshProUGUI GameOverHighScoreText;

    private bool _gameOver;
    private int _highScore;
   
    void Start()
    {
      scoreText.gameObject.SetActive(false);
      mainMenu.SetActive(true);
      GameOverMenu.SetActive(false);
      _gameOver = false;
      _highScore PlayerPrefs.GetInt("Highscore", 0);  
    }

          
    void Update()
    {
       scoreText.text = GameManager.Score.ToString();

       if (!_gameOver && GameManager.GameOver)
       {
        _gameOver = true
        scoreText.gameObject.SetActive(false)
        GameOverMenu.SetActive(true)
       } 
    }
}
