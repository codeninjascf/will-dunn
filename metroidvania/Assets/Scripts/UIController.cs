using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public static UIController instance;

    private void Awake()
    {
        instance = this;
    }

    public Slider healthSlider;
    // Start is called before the first frame update
    public void UpdateHealth(int currentHealth, int maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    
}
