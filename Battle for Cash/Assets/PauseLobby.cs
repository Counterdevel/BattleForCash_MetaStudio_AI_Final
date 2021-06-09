using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class PauseLobby : MonoBehaviour
{
    public Transform box;
    private VariableJoystick joystick;

    private void Start()
    {
        joystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
        box.localPosition = new Vector2(0, -500);
    }

    public void CarregaTelaInicialPhoton()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
        joystick.enabled = true;
    }
    public void Resume()
    {
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
        joystick.enabled = true;
    }

    public void Stop()
    {
        box.localPosition = new Vector2(0, 0);
        joystick.enabled = false;
    }
}
