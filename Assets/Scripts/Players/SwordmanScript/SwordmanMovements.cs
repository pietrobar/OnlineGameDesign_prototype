using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanMovements : MonoBehaviour
{
    Animator animator;
    Rigidbody rigidBody;
    PlayerMovements scriptMovements;

    public GameObject sword;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        scriptMovements = GetComponent<PlayerMovements>();

        sword.GetComponent<SwordmanDamage>().setAnimator(animator);
    }

    void Update()
    {
        if (GameManager.inGame)
        {
            //In questo metodo gestisco le animazioni del player in questione
            animator.SetBool("Block", Input.GetKey(KeyCode.E));


           
            if (Input.GetKeyDown(KeyCode.Mouse0) && GetComponent<PlayerMovements>().isGrounded()) animator.SetTrigger("Attack");
        }
        
    }


}
