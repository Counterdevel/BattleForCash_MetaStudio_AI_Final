using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class Pause : MonoBehaviour
{
    public Transform box;
    public Button[] buttons;
    private VariableJoystick joystick;

    private void Start()
    {
        joystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
        box.localPosition = new Vector2(0, -500);
    }

    public void CarregaTelaInicial()
    {
        SceneManager.LoadScene(0);
        buttons[0].interactable = true;
        joystick.enabled = true;
    }
    public void CarregaTelaInicialPhoton()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
        buttons[0].interactable = true;
        joystick.enabled = true;
    }
    public void Resume()
    {   
        Time.timeScale = 1f;
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
        buttons[0].interactable = true;
        joystick.enabled = true;
    }

    public void Stop()
    {
        box.localPosition = new Vector2(0, 0);
        Time.timeScale = 0f;
        buttons[0].interactable = false;
        joystick.enabled = false;
    }
}
