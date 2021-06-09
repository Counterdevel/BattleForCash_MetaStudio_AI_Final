using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseOpenAnim : MonoBehaviour
{

    public CanvasGroup background;
    void Start()
    {
        transform.localScale = Vector2.zero;
    }

    public void Open()
    {
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);
        transform.LeanScale(Vector2.one, 0.8f);
    }

    public void Close()
    {
        background.LeanAlpha(0, 0.5f);
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }
}
