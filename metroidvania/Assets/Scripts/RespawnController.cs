using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour
{
    public static RespawnController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
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
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        player.SetActive(false);
        yield return new WaitForSeconds(waitToRespawn);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        player.transform.position = respawnPoint;
        player.SetActive(true);
        PlayerHealthController.instance.FillHealth();
    }

    public void SetSpawn(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
