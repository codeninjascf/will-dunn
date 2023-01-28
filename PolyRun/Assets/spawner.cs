using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public float objectSpeed = 8f;
    private List<GameObject>_activeObject;

    void start()
    {
     _activeObject = new List<GameObject>();
     StartCoroutine(Spawn());
    }
    
    void Update()
    {
        Vector3 movement = objectSpeed * Time.deltaTime * Vector3.left;
        foreach (GameObject activeObject in _activeObject)
        {
            activeObject.transform.position += movement;
        }
        GameManager.UpdateScore(movement);
    }

    IEnumerator Spawn()
    {
        GameManager.UpdateList(_activeObject);
        GameObject challengeObject = Instantiate(GameManager.GetChallengeObject());
        challengeObject.transform.position = new Vector3(GameManager.ScreenBounds.x, 0);
        _activeObject.Add(challengeObject);
        ChallengeObject script = challengeObject.GetComponent<ChallengeObject>();
        yield return new WaitForSeconds(script.challengeTime);
        StartCoroutine(Spawn());
    }
}
