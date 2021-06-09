using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform cameraTarget;
    public float speed;
    public Vector3 dist;
    public Transform lookTarget;
    public PhotonView photonview;

    private void Start()
    {
        photonview = GetComponent<PhotonView>();
        if (photonview.IsMine)
        {
            cameraTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            lookTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    private void LateUpdate()
    {
        Vector3 desiredpos = cameraTarget.position + dist;
        Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, speed);
        transform.position = smoothedpos;
        transform.LookAt(lookTarget.position);
    }

}
