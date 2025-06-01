using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    public static RespawnController instance;

    private void Awake()
    {
        instance = this;
    }

    public Vector3 respawnPoint;
    public float waitToRespawn;
    private GameObject player;
    void Start()
    {
        player = PlayerHealthController.instance.gameObject;
        respawnPoint = player.transform.position;
    }

    public void Respawn()
    {
        StartCoroutine(RespawnCo())
    }

    IEnumerator RespawnCo()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.transform.position
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
