using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float currentTime = 0f;
    public float startingTime = 60f;

    [SerializeField] Text countdownText;

    private void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("F2");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }
}
