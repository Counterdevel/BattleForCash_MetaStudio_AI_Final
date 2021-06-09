using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animations : MonoBehaviour
{
    private VariableJoystick joystick;
    public Button Jump;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        joystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>(); 
    }

    private void Update()
    {
        if (joystick.Horizontal >= 0.1 || joystick.Horizontal <= -0.1 || joystick.Vertical >= 0.1 || joystick.Vertical <= -0.1)
        {
            CorridaAnim();
        }
        else
        {
            animator.SetBool("Speed", false);
        }
        Jump.onClick.AddListener(AnimJump);

    }

    public void CorridaAnim()
    {
        animator.SetBool("Speed", true);       
    }
    public void AnimJump()
    {
        animator.SetBool("Jump", true);
        StartCoroutine(AcabouPulo(0.5f));
    }

    private IEnumerator AcabouPulo(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        animator.SetBool("Jump", false);
    }
}
