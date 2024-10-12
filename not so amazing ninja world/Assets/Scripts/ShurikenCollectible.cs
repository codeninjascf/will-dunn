using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenCollectible : MonoBehaviour
{
    public int collectibleValue = 1;

    public GameManager gameManager;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.Shurikens += collectibleValue;
            gameObject.SetActive(false);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
