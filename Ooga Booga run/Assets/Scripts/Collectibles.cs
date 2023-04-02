using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    public ParticleSystem poof;
   
    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.CompareTag("Coin"))
        {
            GameManager.Score++;
            other.gameObject.SetActive(false);
            poof.Play();
        }
    }
}
