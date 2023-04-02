using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    private int _lives = 3;


    public int GetLives()
    {
        return _lives;
    }

    public void SetLives(int lives)
    {
        _lives = lives;
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _lives--;

            if (_lives == 0)
            {
                GameManager.GameOver = true;
            }
            else
            {
                Destroy(other.gameObject);
            }
        }
    }
}
