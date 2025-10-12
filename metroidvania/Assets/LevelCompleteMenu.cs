using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{

    public int levelNumber;
    public GameObject levelCompleteMenu;
    public GameObject player;
    private int _currentCheckpoint;
    public string nextLevelName;
    public string menuSceneName;
    public bool nextScene;

    // Start is called before the first frame update
    void Start()
    {
        _currentCheckpoint = 0;
        levelCompleteMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReachedGoal()
    {
        player.SetActive(false);
        levelCompleteMenu.SetActive(true);
        levelCompleteMenu.GetComponent<Animator>().SetTrigger("Activate");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void LoadNextLevel()
    {
        nextScene = true;
    }
}
