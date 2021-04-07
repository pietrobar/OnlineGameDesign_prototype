﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float fastRunCoeff = 1.5f;

    Animator animator;
    Vector3 movement;
    Quaternion rotation = Quaternion.identity;//per salvare il valore della rotazione
    public float turnSpeed = 20f;
    public float jumpForce;
    Rigidbody rigidBody;
    Transform trans;

    public Transform groundCheckTransform;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }

    void FixedUpdate()//To make sure the movement vector and rotation are set in time with OnAnimatorMove, change your Update method to a FixedUpdate
    {
        float horizontal = Input.GetAxis("Horizontal");//prendo l'input orizzontale (A e D)
        float vertical = Input.GetAxis("Vertical");//prendo l'input verticale (W e S)

        movement.Set(horizontal, 0f, vertical);//salvo gli spostamenti che devo fare
        movement.Normalize();//perche' pitagora fa schifo, si sposta piu' velocemente sulla diagonale

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);//guarda se i parametri passati sono approssimativamente uguali, se lo sono vuol dire che non si sta muovendo lungo l'asse
        bool running = hasHorizontalInput || hasVerticalInput;

        animator.SetBool("Running", running);//attivo l'animazione


        Vector3 desiredForward = Vector3.RotateTowards(trans.forward, movement, turnSpeed * Time.deltaTime, 0f);//calcolo verso dove ruotare il personaggio

        rotation = Quaternion.LookRotation(desiredForward);//salvo la rotazione

        animator.SetBool("Jumping", Input.GetKeyDown(KeyCode.Space));

        


    }

    //OnAnimatorMove is actually going to be called in time with physics, and not with rendering like your Update method
    private void OnAnimatorMove()//This method allows you to apply root motion as you want, which means that movement and rotation can be applied separately.
    {
        if (Input.GetKey(KeyCode.LeftShift))
            rigidBody.MovePosition(rigidBody.position + movement * fastRunCoeff );//applico il movimento con velocita' maggiore
        else
            rigidBody.MovePosition(rigidBody.position + movement * animator.deltaPosition.magnitude);//applico il movimento

        if (animator.GetBool("Jumping") && isGrounded())
        {
            if(rigidBody.velocity.x>=0 || rigidBody.velocity.z >= 0)//voglio continuare a muovermi anche quando salto
            {
                rigidBody.AddForce(new Vector3(movement.x,1f,movement.z)* jumpForce , ForceMode.VelocityChange);//salta solo se e' a terra

            }
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);//salta solo se e' a terra
        }
        

        rigidBody.MoveRotation(rotation);//applica la rotazione
    }

    public Vector3 getMovement()
    {
        return movement;
    }

    public bool isGrounded()
    {
        //overlapSphere ritorna un array di collider, se la sfera non tocca nessun collider(a parte quello del giocatore stesso vuol dire che sono a terra
        return Physics.OverlapSphere(groundCheckTransform.position, 0.3f).Length > 1;
    }
}
