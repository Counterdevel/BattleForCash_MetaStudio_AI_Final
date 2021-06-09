using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaUmManagerOff : MonoBehaviour
{
    int allplayers;
    public List<GameObject> players;
    public List<GameObject> playerseliminados;
    [Header("UI Elements")]
    public GameObject panel;
    public Text quartoLugar;
    public Text terceiroLugar;
    public Text segundoLugar;
    public Text primeiroLugar;

    private void Start()
    {
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        allplayers = players.Count;
    }

    private void Update()
    {
        if (allplayers == 1)
        {
            panel.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Player"))
        {
            other.gameObject.SetActive(false);
            ranking(other.gameObject);
        }
    }

    public void ranking(GameObject playeratingindo)
    {

        playerseliminados.Add(playeratingindo);
        players.Remove(playeratingindo);
        allplayers--;

        if (allplayers == 1)
        {
            quartoLugar.text = playerseliminados[0].name;
            if (playerseliminados[0].GetComponent<PlayerOff>().isNPC == false)
            {
                playerseliminados[0].GetComponent<PlayerOff>().atualizaSaldo(0);
            }

            terceiroLugar.text = playerseliminados[1].name;
            if (playerseliminados[1].GetComponent<PlayerOff>().isNPC == false)
            {
                playerseliminados[1].GetComponent<PlayerOff>().atualizaSaldo(5);
            }

            segundoLugar.text = playerseliminados[2].name;
            if (playerseliminados[2].GetComponent<PlayerOff>().isNPC == false)
            {
                playerseliminados[2].GetComponent<PlayerOff>().atualizaSaldo(10);
            }

            primeiroLugar.text = players[0].name;
            if (players[0].GetComponent<PlayerOff>().isNPC == false)
            {

                players[0].GetComponent<PlayerOff>().atualizaSaldo(20);
            }

            StartCoroutine(AcabouJogo(5f));
        }
    }

    IEnumerator AcabouJogo(float someParameter)
    {
        yield return new WaitForSeconds(someParameter);
        RandomSceneOff.Instance.LoadScene(4);
    }
}
