using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TocoOff : MonoBehaviour
{
    public float speed = 50;
    void Update()
    {
       Rotate();
    }

    void Rotate()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
