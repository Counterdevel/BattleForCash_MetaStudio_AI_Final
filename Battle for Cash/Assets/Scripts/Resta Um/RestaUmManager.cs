using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestaUmManager : MonoBehaviour
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
        if (allplayers == 4)
        {
            gameObject.GetComponent<CaiChão>().enabled = true;
        }
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
            playerseliminados[0].GetComponent<Player>().saldo += 0;
            players[0].GetComponent<Player>().atualizaSaldo();

            terceiroLugar.text = playerseliminados[1].name;
            playerseliminados[1].GetComponent<Player>().saldo += 5;
            playerseliminados[1].GetComponent<Player>().atualizaSaldo();

            segundoLugar.text = playerseliminados[2].name;
            playerseliminados[2].GetComponent<Player>().saldo += 10;
            playerseliminados[2].GetComponent<Player>().atualizaSaldo();

            primeiroLugar.text = players[0].name;
            players[0].GetComponent<Player>().saldo += 20;
            players[0].GetComponent<Player>().atualizaSaldo();
        }
    }
}
