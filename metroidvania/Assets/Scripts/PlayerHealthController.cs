using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{

    public static PlayerHealthController instance;

    private void Awake()
    {
        instance = this;
    }

    [HideInInspector]
    public int maxHealth;
    public int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void DamagePlayer()
    {
        if (currentHealth <=  0) 
        {
            currentHealth = 0;
            gameObject.SetActive(false);
        }
    }
}
