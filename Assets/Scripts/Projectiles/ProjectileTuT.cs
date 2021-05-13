using System.Collections;
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
            if (collision.gameObject.tag == "Enemy")
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(force/100 + 0.1f + (PanelEXP.valueAttack / 50));


            Destroy(impact, 2);
            Destroy(gameObject);
        }
    }
}
