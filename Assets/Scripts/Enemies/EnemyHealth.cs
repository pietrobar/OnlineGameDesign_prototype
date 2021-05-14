using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Photon.MonoBehaviour
{
    public float maxHealth = 4f;
    public float currentHealth;
    public int expGiven = 10;

    public HealthBar healthBar;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }
    [PunRPC]
    void HitBySwordRPC(string type, float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0f)
            SimpleDie(type);
        else
            animator.SetTrigger("getHit");
    }


    public void TakeDamage(string type,float damage)
    {
        if (type == "Swordman")
        {//se il colpo arriva dalla spada devo sincronizzare il danno con tutti, la freccia e la palla sono sincronizzate tramite le loro rpc invece la spada no, quindi in locale un arciere ad esempio non puo' sapere che la spada ha colpito il golem dato che non e' sincronizzata
            object[] ps = { type, damage };
            photonView.RPC("HitBySwordRPC", PhotonTargets.All, ps);
        }
        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if (currentHealth <= 0f)
                SimpleDie(type);
            else
                animator.SetTrigger("getHit");
        }
        
    }

    private void SimpleDie(string type)
    {
        animator.SetTrigger("die");
        
        
        if(GameManager.instance._player.name==type)
            CountXP.setXP(expGiven);
        Destroy(gameObject,2);
    }
}
