using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    Animator anim;
    public AudioSource footSteps;
    public AudioSource mussu;


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
            mussu.Play();
            
        }
    }
}
