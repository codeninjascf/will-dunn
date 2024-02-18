using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothingTime = .2f;
    public Vector3 cameraOffset;
    public float deathHeight = -5;

    private bool _following;
    private float _cameraHeight;

    private Vector3 _velocity;
    // Start is called before the first frame update
    void Start()
    {
     _following = true;
     _cameraHeight =  transform.position.y =
        Camera.main.ViewportToWorldPoint(Vector3.zero);   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = new Vector3 (target.position.x,target.position.y,
            transform.position.z) + cameraOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPos,
            ref _velocity, smoothingTime);
    }
}
