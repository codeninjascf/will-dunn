using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    private int damageAmount = 10000;
    public float XCoordSpawn;
    public float YCoordSpawn;
    public GameObject spawnPoint;
    

    public LevelCompleteMenu LevelCompleteMenu;


    public void DealDamage()
    {
        PlayerHealthController.instance.DamagePlayer(damageAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LevelCompleteMenu.nextScene == true)
        {
            if (collision.CompareTag("Player"))
            {
                DealDamage();
                SceneManager.LoadScene(sceneToLoad);
                PlayerHealthController.instance.gameObject.transform.position = new Vector3(PlayerHealthController.instance.gameObject.transform.position.x, PlayerHealthController.instance.gameObject.transform.position.y, PlayerHealthController.instance.gameObject.transform.position.z);
                DealDamage();
                LevelCompleteMenu.ReachedGoal();
                LevelCompleteMenu.nextScene = false;

            }
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

