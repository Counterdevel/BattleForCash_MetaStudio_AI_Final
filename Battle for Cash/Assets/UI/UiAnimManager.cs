using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiAnimManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject botoes;
    public GameObject logo;
    public GameObject btnVoltar;
    public GameObject SelecaoDePersonagemMultiplayer;
    public GameObject SelecaoDePersonagemSingleplayer;
    public GameObject TipoDeGameplay;
    public GameObject nomePn;
    public InputField playerNameInput;
    string tempPlayerName;
    void Start()
    {
        btnVoltar.transform.localPosition = new Vector2(-500, 0);
        SelecaoDePersonagemMultiplayer.transform.LeanScale(Vector2.zero, 0f);
        SelecaoDePersonagemSingleplayer.transform.LeanScale(Vector2.zero, 0f);
        TipoDeGameplay.transform.LeanScale(Vector2.zero, 0f);
        nomePn.transform.localPosition = new Vector2(0, 500);

        tempPlayerName = "Jogador";
        playerNameInput.text = tempPlayerName;
    }

    public void NomePlayer()
    {
        if (playerNameInput.text != "")
        {
            PlayerPrefs.SetString("Nome",playerNameInput.text);
        }
        else
        {
            PlayerPrefs.SetString("Nome", tempPlayerName);
        }
    }
    public void ClicouJogar()
    {
        TipoDeGameplay.transform.LeanScale(Vector2.one, 1f);
        btnVoltar.transform.LeanMoveLocalX(0, 1f);
        logo.transform.LeanScale(Vector2.zero, 0.8f).setEaseInBack();
        botoes.transform.LeanScale(Vector2.zero, 0.8f).setEaseInBack();
    }
    public void ClicouOffline()
    {
        SelecaoDePersonagemSingleplayer.transform.LeanScale(Vector2.one, 1f);
        TipoDeGameplay.transform.LeanScale(Vector2.zero, 0f);
    }
    public void ClicouMultiplayer()
    {
        SelecaoDePersonagemMultiplayer.transform.LeanScale(Vector2.one, 1f);
        TipoDeGameplay.transform.LeanScale(Vector2.zero, 0f);
    }

    public void ClicouSelecionar()
    {
        SelecaoDePersonagemMultiplayer.transform.LeanScale(Vector2.zero, 1f);
    }

    public void ClicouSelecionarOff()
    {
        SelecaoDePersonagemSingleplayer.transform.LeanScale(Vector2.zero, 1f);
        nomePn.transform.LeanMoveLocalY(0, 1f);
    }
    public void ClicouVoltar()
    {
        logo.transform.LeanScale(Vector2.one, 1f).setEaseInOutElastic();
        botoes.transform.LeanScale(Vector2.one, 1f);
        btnVoltar.transform.LeanMoveLocalX(-300, 1f);
        SelecaoDePersonagemMultiplayer.transform.LeanScale(Vector2.zero, 0f);
        SelecaoDePersonagemSingleplayer.transform.LeanScale(Vector2.zero, 0f);
        TipoDeGameplay.transform.LeanScale(Vector2.zero, 0f);      
        nomePn.transform.localPosition = new Vector2(0, 500);
    }
}
