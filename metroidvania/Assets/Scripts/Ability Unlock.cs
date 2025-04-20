using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUnlock : MonoBehaviour
{
    public bool unlockDoubleJump, unlockDash, unlockBall, unlockDropBomb;

    public GameObject AbilityEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            PlayerAbilityTracker player = other.GetComponentInParent<PlayerAbilityTracker>();

            if (unlockDoubleJump)
            {
                player.canDoubleJump = true;
            }
            if (unlockDash)
            {
                player.canDash = true;
            }

            if (unlockDoubleJump)
            {
                player.canBecomeBall = true;
            }
            if (unlockDropBomb)
            {
                player.canDropBomb = true;
            }

            if(AbilityEffect != null)
            {
                Instantiate(AbilityEffect, transform.position, Quaternion.identity);
            }

            Destroy(AbilityEffect);

            Destroy(gameObject);
        }

        
    }
}
