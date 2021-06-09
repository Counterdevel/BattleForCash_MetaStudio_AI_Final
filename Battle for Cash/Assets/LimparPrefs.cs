using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimparPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}
