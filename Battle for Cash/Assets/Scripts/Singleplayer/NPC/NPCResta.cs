using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCResta : MonoBehaviour
{
    Animator animator; 

    public float speed = 8f; //Variavel para definir a velocidade do NPC

    int randomIndex;    //Variavel para definir o index dos waypoints
    float time = 0;     //Variavel para setar o tempo
    bool isGrounded;    //Variavel para chegar se há chão

    public Transform[] wayPoint;    //Array para definir os waypoints

    private void Start()
    {
        animator = GetComponent<Animator>();

        randomIndex = Random.Range(0, wayPoint.Length); //Deixa o index do array dos waypoints aleatório
    }

    private void Update()
    {
        MoveRandom();
        
        time += 1 * Time.deltaTime;
        if(time >= 2)                   //Cria um loop de tempo
        {
            time = 0;
        }

        animator.SetBool("Speed", true);    //ativa a animação de run do NPC
    }

    public void MoveRandom()
    {
        float distance = Vector3.Distance(transform.position, wayPoint[randomIndex].position);  //Variavel que pega a distancia entre o npc e os waypoints

        if(distance < 5f || isGrounded == false || time == 2)
        {
            randomIndex = Random.Range(0, wayPoint.Length); //Pega um index aleatória se uma das condições forem executadas
        }

        Quaternion rotate = Quaternion.LookRotation(wayPoint[randomIndex].position);    //Rotaciona o NPC na direção dos waypoints
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, 50f * Time.deltaTime); //Aplica uma suavização

        transform.position = Vector3.MoveTowards(transform.position, wayPoint[randomIndex].position, speed * Time.deltaTime); //Move o NPC na direção dos waypoints
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Ground"))  //Checa se o ´NPC está colidindo ou não com o chão
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
}
