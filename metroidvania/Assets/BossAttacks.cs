using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class BossAttacks : MonoBehaviour
{
    public GameObject[] Attacks; 

    public GameObject currentAttack;
    public int index;
    public BossHealthController bossHealth;

    public IEnumerator chooseAttack()
    {
        while(bossHealth.isAlive);
        {
            index = UnityEngine.Random.Range(0, Attacks.Length);

            currentAttack = Attacks[index];
            currentAttack.SetActive(true);

            yield return new WaitForSeconds(3f);

            currentAttack.SetActive(false);
        }
    }
}
