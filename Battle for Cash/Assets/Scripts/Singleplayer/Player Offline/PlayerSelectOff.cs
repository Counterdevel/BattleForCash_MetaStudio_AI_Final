using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSelectOff : MonoBehaviour
{
    public int playerSelected = 0;
    public GameObject PlayerList;

    private void Start()
    {
        playerSelected = PlayerPrefs.GetInt("HERO");
        SwitchPlayer();
    }
    public void SwitchPlayer()
    {
        int i = 0;

        foreach (Transform item in PlayerList.transform)
        {
            if (i == playerSelected)
            {
                item.gameObject.SetActive(true);
            }
            else
            {
                item.gameObject.SetActive(false);
            }
            i++;
        }
    }
}

