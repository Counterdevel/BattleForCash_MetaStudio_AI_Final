using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public int countdownTime;
    int allplayers;
    public List<GameObject> players;
    public Text countdownText;

    private void Start()
    {
        players.AddRange(GameObject.FindGameObjectsWithTag("Player"));
        allplayers = players.Count;
        if(allplayers == 4)
        {
            StartCoroutine(CountdownToStart());
        }
    }
    IEnumerator CountdownToStart()
    {
        Time.timeScale = 0;
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdownTime--;
        }
        Time.timeScale = 1;
        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);

        countdownText.gameObject.SetActive(false);
    }
}