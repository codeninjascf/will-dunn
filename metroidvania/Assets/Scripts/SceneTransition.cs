using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    private int damageAmount = 10000;
    public float XCoordSpawn;
    public float YCoordSpawn;


    public void DealDamage()
    {
        PlayerHealthController.instance.DamagePlayer(damageAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DealDamage();
            SceneManager.LoadScene(sceneToLoad);
            DealDamage();
            collision.gameObject.transform.position = new Vector3(XCoordSpawn, YCoordSpawn, transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DealDamage();
        }
    }
}
