using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealth : MonoBehaviour
{
    public float maxHealth = 4f;
    public float currentHealth;

    public HealthBar healthBar;

    private float increaseHealtXP;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(0.50f);
        }
    }

    public void TakeDamage(float damage)
    {
        
        if(PanelEXP.valueHealth != 0)
        {
            currentHealth -= damage / PanelEXP.valueHealth;
            healthBar.SetHealth(currentHealth);
        }
        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void GiveLife(float life)
    {
        currentHealth += life;
        healthBar.SetHealth(currentHealth);
    }

    public void setHealthBar(HealthBar healthBar)
    {
        this.healthBar = healthBar;
    }

    public float GetHealtValueXP()
    {
        return increaseHealtXP = GetComponent<GameManager>().GetHealtBarValue();
    }
}
