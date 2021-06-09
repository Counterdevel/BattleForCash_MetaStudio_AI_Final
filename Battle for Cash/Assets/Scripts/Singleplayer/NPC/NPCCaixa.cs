using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCCaixa : MonoBehaviour
{
    Animator animator;
    Rigidbody rigibody;

    public Transform[] waypoints;   //Array para definir os waypoints

    public float speed;   //Variavel para definir a velocidade do NPC

    int index;  //Variavel para definir o index dos waypoints

    private void Start()
    {
        rigibody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        index = Random.Range(0, 88);   //Deixa o index do array dos waypoints aleatório
    }

    private void Update()
    {
        MoveRandom();

        animator.SetBool("Speed", true);    //Ativa a animação de run do NPC
    }

    public void MoveRandom()
    {
        float distance = Vector3.Distance(transform.position, waypoints[index].position);   //Variavel que pega a distancia entre o npc e os waypoints

        if (distance < 2)   //Se a distancia entre o NPC e o waypoint for menor que 2 unidades o index seta um valor aleatório
        {
            index = Random.Range(0, 88);    
        }

        Quaternion rotate = Quaternion.LookRotation(waypoints[index].position); //Rotaciona o NPC na direção dos waypoints
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, 50f * Time.deltaTime);    //Aplica uma suavização

        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, speed * Time.deltaTime);    //Move o NPC na direção dos waypoints
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Caixa") || collision.collider.CompareTag("Parede"))   //Seta um index aleatório se NPC colidir com a parede ou caixa
        {
            index = Random.Range(0, 88);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Caixa") || collision.collider.CompareTag("Parede"))
        {
            index = Random.Range(0, 88);
        }
    }
}
