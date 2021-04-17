﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTuT : MonoBehaviour
{
    private bool collided;
    public GameObject impactVFX;
    public int force;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            var impact = Instantiate(impactVFX, collision.contacts[0].point, Quaternion.identity) as GameObject;
            Destroy(impact, 2);
            Destroy(gameObject);
        }
    }
}
