using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toco : MonoBehaviour
{
    public float speed = 50;
    void Update()
    {
       Rotate();
    }

    [PunRPC]
    void Rotate()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
