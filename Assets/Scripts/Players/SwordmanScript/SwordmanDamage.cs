using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanDamage : MonoBehaviour
{
    //private Animator animator;
    private Animator animator;
    public float swordDamage = 1f;

    public void setAnimator(Animator fatherAnimator)
    {
        animator = fatherAnimator;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage("Swordman",swordDamage);
        }
    }
}
