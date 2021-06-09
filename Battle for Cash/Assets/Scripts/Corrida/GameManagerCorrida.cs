using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerCorrida : MonoBehaviour
{
    int allplayers;
    public List<GameObject> players;
    public List<GameObject> playersvencedores;
    [Header("UI Elements")]
    public GameObject panel;
    public Text quartoLugar;
    public Text terceiroLugar;
    public Text segundoLugar;
    public Text primeiroLugar;

    void Start()
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
        if (other.CompareTag("Player"))
        {
            ranking(other.gameObject);
        }

    }
    public void ranking(GameObject playeratingindo)
    {
        playersvencedores.Add(playeratingindo);
        players.Remove(playeratingindo);
        allplayers--;

        if (allplayers == 1)
        {
            quartoLugar.text = players[0].name;
            players[0].GetComponent<Player>().saldo += 0;
            players[0].GetComponent<Player>().atualizaSaldo();

            terceiroLugar.text = playersvencedores[2].name;
            playersvencedores[2].GetComponent<Player>().saldo += 5;
            playersvencedores[2].GetComponent<Player>().atualizaSaldo();

            segundoLugar.text = playersvencedores[1].name;
            playersvencedores[1].GetComponent<Player>().saldo += 10;
            playersvencedores[1].GetComponent<Player>().atualizaSaldo();

            primeiroLugar.text = playersvencedores[0].name;
            playersvencedores[0].GetComponent<Player>().saldo += 20;
            playersvencedores[0].GetComponent<Player>().atualizaSaldo();
        }
    }
}