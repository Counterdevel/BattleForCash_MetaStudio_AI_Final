using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuvaDeCaixaOff : MonoBehaviour
{
    public GameObject caixa;
    GameObject DestroyComponents;
    public float inicioChuva = 3f;
    public float intervalo = 1f;
    private List<Vector3> PosicoesJaSalvas = new List<Vector3>();

    public float[] positionsx;
    public float[] positionsz;
    int x;
    int z;

    void Start()
    {
        InvokeRepeating("RespawnCaixa", inicioChuva, intervalo);
    }
    public void RespawnCaixa()
    {
        x = Random.Range(0, 11);
        z = Random.Range(0, 8);
        Vector3 position = new Vector3(positionsx[x], 35, positionsz[z]);
        float tamanholist = PosicoesJaSalvas.Count;
        if (tamanholist == 88) 
        {
            CancelInvoke("RespawnCaixa");
        }
        else if (PosicoesJaSalvas.Contains(position))
        {
            RespawnCaixa();
        }
        else
        {
            DestroyComponents = Instantiate(caixa, position, transform.rotation);
            Destroy(DestroyComponents.GetComponent<Rigidbody>(), 5);
            PosicoesJaSalvas.Add(position);
        } 
    }
}
