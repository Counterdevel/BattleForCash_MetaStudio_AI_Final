using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacle;

    private void Start()
    {
        int random = Random.Range(0, obstacle.Length);
        SpawnaObjeto(random);
    }
    [PunRPC]
    private void SpawnaObjeto(int random)
    {
        Instantiate(obstacle[random], transform.position, Quaternion.identity);
    }
}
