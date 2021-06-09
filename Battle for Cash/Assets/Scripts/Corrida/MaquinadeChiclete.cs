using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MaquinadeChiclete : MonoBehaviour
{
    public GameObject prefabBala;
    public float tempoderepetição;
    public AudioSource somTiro;
    void Start()
    {
        InvokeRepeating("disparaBala",0, tempoderepetição);
    }
 
    [PunRPC]
    void disparaBala()
    {
        Instantiate(prefabBala,transform.position, transform.rotation);
        somTiro.Play();
    }
}
