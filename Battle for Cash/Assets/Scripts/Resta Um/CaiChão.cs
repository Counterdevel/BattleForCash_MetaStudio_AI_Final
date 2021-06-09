using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CaiChão : MonoBehaviour
{
    public List<GameObject> chaos;
    GameObject chao;
    public float inicioChuva = 2f;
    public float intervalo = 5f;
    void Start()
    {
        chaos.AddRange(GameObject.FindGameObjectsWithTag("Ground"));
        InvokeRepeating("Caichao", inicioChuva, intervalo);
    }
    [PunRPC]
    void Caichao()
    {
        int index = Random.Range(0, chaos.Count);
        chao = chaos[index];
        chaos[index].GetComponent<MeshRenderer>().material.color = Color.red;
        chaos[index].GetComponent<Rigidbody>().isKinematic = false;
        chaos.Remove(chao);

        if (chaos.Count == 0)
        {
            CancelInvoke("Caichao");
        }
    }
}
