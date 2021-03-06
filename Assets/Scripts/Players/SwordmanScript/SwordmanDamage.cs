using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordmanDamage : Photon.MonoBehaviour
{
    //private Animator animator;
    private Animator animator;
    public float swordDamage = 1f;
    private bool isColliding = false;

    //AUDIO
    public AudioSource swordHit;

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(0.65f);
        isColliding = false;
    }

    public void setAnimator(Animator fatherAnimator)
    {
        animator = fatherAnimator;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.instance.GetInstantiatedPlayers()[2] != null)
        {
            if (other && other.tag == "Enemy" && animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                
                if (isColliding) return;

                swordHit.Play();
                isColliding = true;
                StartCoroutine(Reset());

                other.gameObject.GetComponent<EnemyHealth>().TakeDamage("Swordman", swordDamage + (PanelEXP.valueAttack / 50));
            }
        }
        
        
        
        
    }
}
