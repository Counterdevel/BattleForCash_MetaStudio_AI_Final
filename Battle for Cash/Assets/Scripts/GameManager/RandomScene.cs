using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomScene : MonoBehaviour
{
    static List<int> availableScenes =new List<int> { 1, 2, 3};

    public void LoadNextScene()
    {
        int index = Random.Range(0, availableScenes.Count);
        int theSceneIndex = availableScenes[index];
        availableScenes.Remove(theSceneIndex);
        SceneManager.LoadScene(theSceneIndex);
        if (availableScenes.Count == 0)
            {
            Debug.Log("Acabou as fases, recomeçando");
            availableScenes = new List<int> { 1, 2, 3};
        }
    }
}
