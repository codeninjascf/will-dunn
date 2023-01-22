using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
   public objectSpeed = 8f;
      
        private List<GameObject>_activeObject
    
    
    void Update()
    {
        Vector3 movement = objectSpeed * Time.deltaTime * Vector3.left;
        foreach (GameObject activeObject in _activeObjects)
        {
            activeObject.transform.position += movement;
        }
        GameManager.UpdateScore(movement);
    }

    IEnumerator Spawn()
    {
        GameManager.UpdateList(_activeObjects);
        GameObject challengeObject = Instantiate(GameManager.GetChallengeObject())
        challengeObject.transform.position = new Vector3(GameManager.ScreenBounds.x, 0);
        _activeObject.Add(challengeObject);
        challengeObject script = challengeObject.GetComponent<ChallengeObject>();
    }
}
