using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthController : MonoBehaviour
{
    public static BossHealthController instance;

    void Awake()
    {
        instance = this;
    }

    public Slider bossHealthSlider;
    public int currentHealth = 100;
    public BossBattle boss;
    void Start()
    {
        bossHealthSlider.maxValue = currentHealth;
        bossHealthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        print("RAHAAHAHAHAHAHAHAHAHAHAHAHAH");
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            boss.EndBattle(); 
        }
        bossHealthSlider.value = currentHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
