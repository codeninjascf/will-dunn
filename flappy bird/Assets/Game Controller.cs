using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game Controller : MonoBehaviour
{
    [Header("Game Over UI Object for displaying Game Over Screen")]
    public GameObject gameOverCanvas;
    [Header("Score UI Object for displaying Score ")]
    public GameObject scoreCanvas;
    [Header("Spawner UI Object for spawning objects in game ")]
    public GameObject Spawner;
    void Start()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        Spawner.SetActive(true);
    }

    // Update is called once per frame
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Spawner.SetActive(false);
        Time.timeScale = 0;
    }
}
