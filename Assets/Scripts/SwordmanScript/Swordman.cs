using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordman : MonoBehaviour
{
    Animator m_Animator;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;//per salvare il valore della rotazione
    public float turnSpeed = 20f;
    public float jumpForce;
    Rigidbody m_Rigidbody;
    Transform transform;



    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    void FixedUpdate()//To make sure the movement vector and rotation are set in time with OnAnimatorMove, change your Update method to a FixedUpdate
    {
        float horizontal = Input.GetAxis("Horizontal");//prendo l'input orizzontale (A e D)
        float vertical = Input.GetAxis("Vertical");//prendo l'input verticale (W e S)

        m_Movement.Set(horizontal, 0f, vertical);//salvo gli spostamenti che devo fare
        m_Movement.Normalize();//perche' pitagora fa schifo, si sposta piu' velocemente sulla diagonale

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);//guarda se i parametri passati sono approssimativamente uguali, se lo sono vuol dire che non si sta muovendo lungo l'asse
        bool running = hasHorizontalInput || hasVerticalInput;

        m_Animator.SetBool("Running", running);//attivo l'animazione


        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);//calcolo verso dove ruotare il personaggio

        m_Rotation = Quaternion.LookRotation(desiredForward);//salvo la rotazione

        m_Animator.SetBool("Jumping", Input.GetKey(KeyCode.Space));
        m_Animator.SetBool("Block", Input.GetKey(KeyCode.E));

    }

    //OnAnimatorMove is actually going to be called in time with physics, and not with rendering like your Update method
    private void OnAnimatorMove()//This method allows you to apply root motion as you want, which means that movement and rotation can be applied separately.
    {
        if(m_Animator.GetBool("Jumping") && transform.position.y<.3f) m_Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);//salta solo se e' a terra
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);//applico il movimento
        m_Rigidbody.MoveRotation(m_Rotation);//applica la rotazione
    }
}
