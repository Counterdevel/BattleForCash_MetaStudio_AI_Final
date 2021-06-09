using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomSceneOff : MonoBehaviour
{
    static List<int> availableScenes =new List<int> { 1, 2, 3};
    public static RandomSceneOff Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void LoadRandomScene()
    {
        int index = Random.Range(0, availableScenes.Count);
        int theSceneIndex = availableScenes[index];
        availableScenes.Remove(theSceneIndex);
        SceneManager.LoadScene(theSceneIndex);
        if (availableScenes.Count == 0)
        {
            SceneManager.LoadScene(4);
        }
    }
}
