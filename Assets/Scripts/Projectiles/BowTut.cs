using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTut : MonoBehaviour
{
    private bool collided;
    public int force;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet" && collision.gameObject.tag != "Player" && !collided)
        {
            collided = true;
            transform.GetComponent<Rigidbody>().isKinematic = true; // stop physics
            transform.parent = collision.transform; // doesn't move yet, but will move w/what it hit

            if(collision.gameObject.tag == "Enemy")
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(1f + (PanelEXP.valueAttack / 50));

            Destroy(gameObject,5);
        }
    }
}
