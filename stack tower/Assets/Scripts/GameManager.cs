using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : UnityEngine.MonoBehaviour
{
    public Spawner spawner;
    public CameraFollow view;
    public UIManager uiManager;

    private bool _gameOver;

    // Update is called once per frame
    private void Start()
    {
        spawner.Spawn();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && !_gameOver)
        {
            BlockMovement.CurrentBlock.Stop();
            if (BlockMovement.GameOver)
            {
                _gameOver = true;
            }
            else
            {
                spawner.Spawn();
                view.Height = spawner.GetNewHeight();
                uiManager.Score++;
             }                    
        }
    }
}