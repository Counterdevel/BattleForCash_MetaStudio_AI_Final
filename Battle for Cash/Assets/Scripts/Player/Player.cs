using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{
    public PhotonView photonview;
    public Text playerName;
    public int saldo = 0;
    void Start()
    {
        photonview = GetComponent<PhotonView>();
        if (photonview.IsMine)
        {
            playerName.text = PhotonNetwork.NickName;
            gameObject.name = playerName.text;
            saldo = PlayerPrefs.GetInt("saldoPrefs");
        }
    }

    public void atualizaSaldo()
    {
        PlayerPrefs.SetInt("saldoPrefs", saldo);
    }
}
