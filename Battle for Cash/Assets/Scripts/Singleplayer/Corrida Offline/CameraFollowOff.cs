using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowOff : MonoBehaviour
{
    public Transform cameraTarget;
    public float speed;
    public Vector3 dist;
    public Transform lookTarget;

    private void Start()
    {
            //cameraTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            //lookTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        Vector3 desiredpos = cameraTarget.position + dist;
        Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, speed);
        transform.position = smoothedpos;
        transform.LookAt(lookTarget.position);
    }

}
