using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;
    public GameObject PlayerDeath;
    public float damageCooldown = 1f;
    public int poisonAmount = 1;
    public int poisonDamage = 1;
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
        StartCoroutine(TickDamage());
    }

    public void FillHealth()
    {
        currentHealth = maxHealth;
        poisonAmount = 0;
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


    public IEnumerator TickDamage()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            if (poisonAmount > poisonDamage)
            {
                poisonAmount -= poisonDamage;
                DamagePlayer(poisonDamage);
            } 
            else if (poisonAmount > 0)
            {
                poisonAmount = 0;
                DamagePlayer(poisonDamage);
            }
            print("tick");
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

    public void DamagePlayerOverTime(int damageAmount)
    {
        if (poisonAmount < damageAmount)
        {
            poisonAmount = damageAmount;
        }
    }

    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        poisonAmount = 0;
        UIController.instance.UpdateHealth(currentHealth, maxHealth);
    }
}

