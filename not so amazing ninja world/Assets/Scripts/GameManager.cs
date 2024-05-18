using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public int levelNumber;
    public float respawnDelay = 1.5f;
    public PlayerController player;
    public CameraFollow cam;
    public Transform[] checkpoints;
    public Transform[] collectibles;
    public GameObject deathParticles;
    public GameObject levelCompleteMenu;
    public RubiesDisplay rubiesDisplay;

    private int _currentCheckpoint;
    private bool[] _collectiblesCollected;

    public void KillPlayer()
    {
        player.Disable();

        player.gameObject.SetActive(false);

        GameObject particles = Instantiate(deathParticles, new
            Vector3(player.transform.position.x, player.transform.position.y),
            Quaternion.identity);
        Destroy(particles, 1f);
        StartCoroutine(ResetPlayer()); 
    }

    IEnumerator ResetPlayer()
    {
        yield return new WaitForSeconds(respawnDelay);
        Vector3 spawnPosition = checkpoints[_currentCheckpoint].position;
        player.Enable();
        player.gameObject.SetActive(true);
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.transform.position = spawnPosition;

        cam.ResetView();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _currentCheckpoint = 0;
        _collectiblesCollected = new bool[3];

        levelCompleteMenu.SetActive(false);
        rubiesDisplay.levelNumber = levelNumber;
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        int checkpointNumber = Array.IndexOf(checkpoints, checkpoint);

        if(checkpointNumber > _currentCheckpoint)
        {
            _currentCheckpoint = checkpointNumber;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GotCollectible(Transform collectible)
    {
        int collectibleNumber = Array.IndexOf(collectibles, collectible);

        _collectiblesCollected[collectibleNumber] = true;
    }
    public void ReachedGoal()
    {
        player.Disable();

        PlayerPrefs.SetInt("Level" + levelNumber + "_Complete", 1);

        for (int i = 0; i < 3; i++)
        {
            if (_collectiblesCollected[i])
            {
                PlayerPrefs.SetInt("Level" + levelNumber + "_Gem" +
                    (i + 1), 1);
            }
            levelCompleteMenu.SetActive(true);
            rubiesDisplay.UpdateRubies();
        }
    }
}

