using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BossAttacks : MonoBehaviour
{

    public GameObject healthPickup;

    public GameObject[] Attacks;
    public GameObject[] SpawnPoints;
    public GameObject[] healthPoints;

    private GameObject currentAttack;
    private GameObject currentSpawn;
    private GameObject currentPickup;
    public BossHealthController bossHealth;

    public float spawnCooldown = 7f;
    public float pickupCooldown = 10f;

    public IEnumerator chooseAttack()
    {
        while(bossHealth.isAlive)
        {
            int index = Random.Range(0, Attacks.Length);

            currentAttack = Attacks[index];
            currentAttack.SetActive(true);

            yield return new WaitForSeconds(3f);

            currentAttack.SetActive(false);
        }
    }

    public IEnumerator chooseSpawn()
    {
        while (bossHealth.isAlive)
        {
            int index = Random.Range(0, SpawnPoints.Length);

            currentSpawn = SpawnPoints[index];
            
            transform.position = currentSpawn.transform.position;

            yield return new WaitForSeconds(spawnCooldown);
        }
    }

    public IEnumerator choosePickup()
    {
        while (bossHealth.isAlive)
        {
            int index = Random.Range(0, healthPoints.Length);

            currentPickup = healthPoints[index];

            yield return new WaitForSeconds(pickupCooldown);

            Instantiate(healthPickup, currentPickup.transform.position, Quaternion.identity);

            
        }
    }

    public void Start()
    {
        StartCoroutine(chooseAttack());
        StartCoroutine(chooseSpawn());
        StartCoroutine(choosePickup());
    }
}
