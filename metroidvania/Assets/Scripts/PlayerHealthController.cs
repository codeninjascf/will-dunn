using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;
    public GameObject PlayerDeath;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

   
    public int maxHealth;
    public int currentHealth;

    public float invincLength, flashLength;
    private float invincCounter, flashCounter;
    public SpriteRenderer[] playerSprites;

    private void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealth(currentHealth,maxHealth);
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;
        UIController.instance.UpdateHealth(currentHealth, maxHealth);
    }

    void Update()
    {
        if(invincCounter > 0 )
        {
            invincCounter -= Time.deltaTime;

            flashCounter -= Time.deltaTime;

            if(flashCounter <= 0)
            {
                foreach(SpriteRenderer sr in playerSprites)
                {
                    sr.enabled = !sr.enabled;
                }
                flashCounter = flashLength;
            }

            if(invincCounter <= 0)
            {
                foreach (SpriteRenderer sr in playerSprites)
                {
                    sr.enabled = true;

                }
                flashCounter = 0f;
            }
        }
    }

    public void DamagePlayer(int damageAmount)
    {
        if(invincCounter == 0)
        {
            currentHealth -= damageAmount;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Instantiate(PlayerDeath, transform.position, transform.rotation);
                RespawnController.instance.Respawn();
            }

            UIController.instance.UpdateHealth(currentHealth, maxHealth);
        }
    }
}

