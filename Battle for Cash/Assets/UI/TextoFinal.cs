using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextoFinal : MonoBehaviour
{
    public Text text;
    void Start()
    {
        text.text = "Você ganhou R$" + PlayerPrefs.GetInt("saldoPrefs")+",00" + " nesta partida!";
    }

    public void TelaInicial()
    {
        SceneManager.LoadScene(0);
    }
}
