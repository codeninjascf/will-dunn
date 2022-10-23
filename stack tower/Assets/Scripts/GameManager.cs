using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Start()
    {
        
    }

    private void Update()
{
    if (Input.GetButtonDown("Fire1") && !_gameOver)
    {
        BlockMovement.CurrentBlock.Stop();
        if (BlockMovement.GameOver)
        {
            _GameOver = true;
        }
        else
        {
            Spawner.Spawn();
            view.Height = spawner
                    }
    }
 }