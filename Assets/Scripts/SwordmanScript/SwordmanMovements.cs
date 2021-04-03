using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanMovements : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidBody;
    PlayerMovements scriptMovements;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        scriptMovements = GetComponent<PlayerMovements>();
    }

    void Update()
    {
        //In questo metodo gestisco le animazioni del player in questione
        animator.SetBool("Block", Input.GetKey(KeyCode.E));
        animator.SetBool("FastRunning", Input.GetKey(KeyCode.LeftShift));

        //voglio discernere i casi in cui corro e voglio attaccare con la spada, e il caso in cui attacco da fermo
        if (Input.GetKeyDown(KeyCode.Mouse0) && (animator.GetBool("FastRunning") || animator.GetBool("Running")))
        {
            //l'animazione dell'attacco in corsa prevede un salto, per eseguirlo prendo il vettore movement dallo script del movimento cosi' da mantenere la velocita' data dalla corsa in modo corretto
            Vector3 movement = scriptMovements.getMovement();
            rigidBody.AddForce(new Vector3(movement.x, 2f, movement.z) *3,ForceMode.VelocityChange);
            animator.SetTrigger("AttackRunning");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0)) animator.SetTrigger("Attack");
        
    }


}
