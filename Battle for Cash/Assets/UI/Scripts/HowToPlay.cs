using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public GameObject transicao;
    public GameObject cena1;
    public GameObject cena2;

    private void Start()
    {
        transicao.transform.localPosition = new Vector2(1200, 0);
        cena2.transform.LeanScale(Vector2.zero, 0f);
    }
    public void carregaHowToPlay()
    {
        transicao.transform.LeanMoveLocalX(-1200, 1.2f);
        cena1.transform.LeanScale(Vector2.zero, 0.8f);
        cena2.transform.LeanScale(Vector2.one, 1.1f);
    }
    public void descarregaHowToPlay()
    {
        transicao.transform.LeanMoveLocalX(1200, 1.2f);
        cena1.transform.LeanScale(Vector2.one, 1.3f);
        cena2.transform.LeanScale(Vector2.zero, 0.8f);
    }

}
