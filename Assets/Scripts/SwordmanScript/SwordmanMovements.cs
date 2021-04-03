using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanMovements : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()//To make sure the movement vector and rotation are set in time with OnAnimatorMove, change your Update method to a FixedUpdate
    {
        animator.SetBool("Block", Input.GetKey(KeyCode.E));
        animator.SetBool("FastRunning", Input.GetKey(KeyCode.LeftShift));
    }
}
