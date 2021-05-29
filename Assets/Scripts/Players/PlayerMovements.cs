using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] float fastRunCoeff = 1.5f;

    Animator animator;
    Vector3 movement;
    public float turnSpeed = 20f;
    public float jumpForce;
    Rigidbody rigidBody;
    Transform trans;
    public float visualRotationSpeed = 3f;
    float visualRotationAngle;

    public Transform groundCheckTransform;


    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();

        //blocco il mouse
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
   

    private void LookAtMouse()//il giocatore segue il mouse ruotando lungo l'asse y, la camera lo segue perche' e' suo figlio nella gerarchia
    {
        visualRotationAngle += Input.GetAxis("Mouse X") * visualRotationSpeed * Time.deltaTime;
        trans.localRotation = Quaternion.AngleAxis(visualRotationAngle, Vector3.up);//ruota solo lungo y  
    }

    void Update()//To make sure the movement vector and rotation are set in time with OnAnimatorMove, change your Update method to a FixedUpdate
    {
        if (GameManager.inGame)//sto controllando il gioco
        {
            LookAtMouse();
            float vertical = Input.GetAxis("Vertical");//prendo l'input verticale (W e S)

            movement = trans.forward * vertical;

            bool running = !Mathf.Approximately(vertical, 0f);//guarda se i parametri passati sono approssimativamente uguali, se lo sono vuol dire che non si sta muovendo lungo l'asse

            //Animazioni comuni a tutti i player
            animator.SetBool("Running", running);//attivo l'animazione

            animator.SetBool("Jumping", Input.GetKeyDown(KeyCode.Space));

            animator.SetBool("FastRunning", Input.GetKey(KeyCode.LeftShift));
        }
        else//se faccio esc devono finire i movimenti
        {
            animator.SetBool("Running", false);
            animator.SetBool("FastRunning", false);
        }
    }

    //OnAnimatorMove is actually going to be called in time with physics, and not with rendering like your Update method
    private void OnAnimatorMove()//This method allows you to apply root motion as you want, which means that movement and rotation can be applied separately.
    {
        if (animator)//controllo che l'animator non sia null
        {
            if (Input.GetKey(KeyCode.LeftShift) && isGrounded())
                //(PanelEXP.valueSpeed / 30) l'ideale sarebbe mettere 20
                rigidBody.MovePosition(rigidBody.position + movement * (fastRunCoeff + (PanelEXP.valueSpeed / 30)) * Time.deltaTime * 50);//applico il movimento con velocita' maggiore
            else
                rigidBody.MovePosition(rigidBody.position + movement * animator.deltaPosition.magnitude * Time.deltaTime * 100);//applico il movimento


            if (animator.GetBool("Jumping") && isGrounded())
            {
                if (rigidBody.velocity.x >= 0 || rigidBody.velocity.z >= 0)//voglio continuare a muovermi anche quando salto
                {
                    rigidBody.AddForce(new Vector3(movement.x, 1f, movement.z) * jumpForce *1.2f, ForceMode.VelocityChange);//salta solo se e' a terra

                }
                rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);//salta solo se e' a terra
            }

        }


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
