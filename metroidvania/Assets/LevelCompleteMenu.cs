using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteMenu : MonoBehaviour
{

    public int levelNumber;
    public GameObject levelCompleteMenu;
    public GameObject player;
    private int _currentCheckpoint;

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
    }
}
