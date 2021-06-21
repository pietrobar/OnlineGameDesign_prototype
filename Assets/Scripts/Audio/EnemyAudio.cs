using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    Animator anim;
    public AudioSource footSteps;

    public AudioSource pain;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (anim.GetBool("walk") && !footSteps.isPlaying && !anim.GetCurrentAnimatorStateInfo(0).IsName("GetHit") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            footSteps.Play();
            
        }
        else if (anim.GetCurrentAnimatorStateInfo(0).IsName("GetHit") || anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            footSteps.Stop();
        }
    }

    //questo metodo e' richiamato da un evento generato dall'animazione del golem
    void PainSound()
    {
        pain.Play();
    }
}
