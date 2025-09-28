using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOverTime : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerHealthController.instance.DamagePlayerOverTime(1);
    }
}