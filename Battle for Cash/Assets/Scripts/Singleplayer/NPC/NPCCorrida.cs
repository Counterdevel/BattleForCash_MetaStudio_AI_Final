using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCCorrida : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    Rigidbody rigidbody;

    public Transform waypoint;  //Pega o waypoint

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        agent.SetDestination(waypoint.position);    //O NPC faz o percurso até o waypoint
        animator.SetBool("Speed", true);    //Ativa a animação de run para o NPC
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Bullet") || collision.collider.CompareTag("Empurra")) //Se NPC colidir com a bullet ou a plataforma que empurra desabilita o agent
        {
            agent.enabled = false;
            StartCoroutine("VoltaCorre", 5);
        }
    }

    private IEnumerator VoltaCorre(float time)  //Cria um timer que quando chega a 0 ativa o agent
    {
        yield return new WaitForSeconds(time);

        agent.enabled = true;
    }

}
