using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementOff : MonoBehaviour
{
    private VariableJoystick joystick;
    public Rigidbody rbPlayer;

    public AudioSource audioSource;
    public AudioClip[] fx;

    public float playerspeed, forcejump; 
    public bool isGround;
    bool podeRotacionar = true;

    Vector3 direction;
    void Start()
    {
        playerspeed = 15;
        joystick = GameObject.Find("Variable Joystick").GetComponent<VariableJoystick>();
        rbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
            MoveMobile();
        if (podeRotacionar)
        {
            Rotation();
        }
            
    }

    void MoveMobile()
    {
        direction = (Vector3.forward * joystick.Vertical) + (Vector3.right * joystick.Horizontal);
    }
    void Rotation()
    {
        if(direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
        transform.Translate(direction * (playerspeed * Time.deltaTime), Space.World);
    }

    public void Jump()
    {
        if (isGround)
        {
            rbPlayer.AddForce(Vector3.up * forcejump, ForceMode.Impulse);
            isGround = false;
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        if (collision.gameObject.CompareTag("Meleca"))
        {
            playerspeed = 7;
            isGround = false;
        }
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            isGround = true;
            this.transform.parent = collision.transform;
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            playerspeed = 5;
            rbPlayer.freezeRotation = false;
            podeRotacionar = false;
            StartCoroutine(Baleado(5f));
        }
        if (collision.gameObject.CompareTag("Empurra"))
        {
            rbPlayer.freezeRotation = false;
        }
    }

    private IEnumerator Baleado(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        playerspeed = 15f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rbPlayer.freezeRotation = true;
        rbPlayer.velocity = Vector3.zero;
        rbPlayer.angularVelocity = Vector3.zero;
        podeRotacionar = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WaterSom"))
        {
            audioSource.PlayOneShot(fx[0]);
        }
        if (other.CompareTag("Water"))
        {
            playerspeed = 15;
            rbPlayer.freezeRotation = true;
            rbPlayer.velocity = Vector3.zero;
            rbPlayer.angularVelocity = Vector3.zero;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            this.transform.parent = null;
        } 
        if (collision.gameObject.CompareTag("Meleca"))
        {
            playerspeed = 15;
        }
        if (collision.gameObject.CompareTag("Empurra"))
        {
            rbPlayer.freezeRotation = true;
        }
        
    }
}
