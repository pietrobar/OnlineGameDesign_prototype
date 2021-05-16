﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static int enemiesKill = 0;
    public float maxHealth = 4f;
    public float currentHealth;
    public int expGiven = 10;

    public Text enimiesKill;

    public HealthBar healthBar;
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
        CountXP.setXP(expGiven);
        enemiesKill++;
        Destroy(gameObject,2); 
    }
}
