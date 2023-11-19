using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public enum LevelType
{
    Time,
    Moves
}

public class Level : MonoBehaviour
{
    public LevelType type;

    public int levelCondition;
    public int firstStar;
    public int secondStar;
    public int thirdStar;

    private string _levelName;

    public int MovesRemaining { get; set;}
    public double TimeRemaining { get; set;}
    public int HighScore { get; set;}

    public bool GameOver => type == LevelType.Moves && MovesRemaining <= 0
    || type == LevelType.Time && TimeRemaining <= 0;
    
    public int StarsAchieved(int Score) => Convert.ToInt32(Score >= firstStar) +
    Convert.ToInt32(Score >= secondStar) +  Convert.ToInt32(Score >= thirdStar);

    public void UpdateHighScore(int Score) => PlayerPrefs.SetInt(_levelName +
    "_HighScore", Math.Max(Score, HighScore));

    public void UpdateStarsAchieved(int Score) => PlayerPrefs.SetInt(_levelName +
    "_Stars", StarsAchieved(Score));

    void Awake()
    {
        _levelName = SceneManager.GetActiveScene().name;

        MovesRemaining = levelCondition;
        TimeRemaining = levelCondition;

        HighScore = PlayerPrefs.GetInt(_levelName + "_HighScore", 0);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      TimeRemaining -= Time.deltaTime;  
    }
}
