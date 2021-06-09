using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnerOff : MonoBehaviour
{
    public GameObject[] obstacle;

    private void Start()
    {
        int random = Random.Range(0, obstacle.Length);
        SpawnaObjeto(random);
    }
    private void SpawnaObjeto(int random)
    {
        Instantiate(obstacle[random], transform.position, Quaternion.identity);
    }
}
