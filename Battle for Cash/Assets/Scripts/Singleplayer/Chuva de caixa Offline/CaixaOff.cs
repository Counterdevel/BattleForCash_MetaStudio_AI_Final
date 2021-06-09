using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaixaOff : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] sons;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            GameManagerCaiCaixaOff.Instance.ranking(other.gameObject);
        }
        if (other.CompareTag("Untagged"))
        {
            audioSource.PlayOneShot(sons[Random.Range(0, sons.Length)]);
        }
        if (other.CompareTag("PurpleNPC"))
        {
            other.gameObject.SetActive(false);
            GameManagerCaiCaixaOff.Instance.ranking(other.gameObject);
        }
    }
}