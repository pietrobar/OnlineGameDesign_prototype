using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    Animator anim;
    public AudioSource footStep;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (anim.GetBool("Running") && !footStep.isPlaying)
        {
            footStep.Play();
        }
    }
}
