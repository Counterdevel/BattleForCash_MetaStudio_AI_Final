using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    [SerializeField] GameObject panelexit;
    public CanvasGroup background;
    public Transform box;
    public Button[] buttons;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().buildIndex != 0)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                if (panelexit)
                {
                    panelexit.SetActive(true);
                    Open();

                }
            }
        }
    }

    public void OnClickYesOrNo(int choice)
    {
        if(choice == 1)
        {
            Application.Quit();
        }
        Close();
    }
    public void Open()
    {
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);

        box.localPosition = new Vector2(0, -Screen.height);
        box.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.1f;

        buttons[0].interactable = false;
        buttons[1].interactable = false;
        buttons[2].interactable = false;
        buttons[3].interactable = false;
        buttons[4].interactable = false;
    }
    public void Close()
    {
        background.LeanAlpha(0, 0.5f);
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
    }

    void OnComplete()
    {
        panelexit.SetActive(false);
        buttons[0].interactable = true;
        buttons[1].interactable = true;
        buttons[2].interactable = true;
        buttons[3].interactable = true;
        buttons[4].interactable = true;
    }
}
