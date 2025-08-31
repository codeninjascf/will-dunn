using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattle : MonoBehaviour
{
    public CameraController cam;
    public Transform camPosition;
    public float camSpeed;
    void Start()
    {
        cam = FindAnyObjectByType<CameraController>();
        cam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, camPosition.position, camSpeed * Time.deltaTime);
    }

    public void EndBattle()
    {
        gameObject.SetActive(false);
    }
}
