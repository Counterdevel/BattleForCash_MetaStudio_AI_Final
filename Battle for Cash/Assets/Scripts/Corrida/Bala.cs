using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float bulletSpeed = 100f;
    Rigidbody bulletRB;
    void Start()
    {
       bulletRB = GetComponent<Rigidbody>();
       bulletRB.AddForce(Vector3.right * bulletSpeed, ForceMode.Impulse);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }
    }
}
