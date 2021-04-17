﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 4f;
    public float currentHealth;
    public int expGiven = 10;

    public HealthBar healthBar;
    public CountXP countXP;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0f)
            SimpleDie();
        else
            animator.SetTrigger("getHit");
    }

    private void SimpleDie()
    {
        animator.SetTrigger("die");
        countXP.AddXP(expGiven);
        Destroy(gameObject,2);
    }
}
