using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSelected : MonoBehaviour
{
    void loadPlayerScene(int value)
    {
        PlayerPrefs.SetInt("HERO", value);
    }

    public void btn1()
    {
        loadPlayerScene(0);
    }
    public void btn2()
    {
        loadPlayerScene(1);
    }
    public void btn3()
    {
        loadPlayerScene(2);
    }
    public void btn4()
    {
        loadPlayerScene(3);
    }
}
