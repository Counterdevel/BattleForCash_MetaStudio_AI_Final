using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform checkpoint;

    void OnTriggerEnter(Collider plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            plyr.transform.position = checkpoint.position;
            plyr.transform.rotation = checkpoint.rotation;
        }
    }
}