using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealth : MonoBehaviour
{
    public float maxHealth = 4f;
    public float currentHealth;
    private GameObject diePanel;
    private Text respawnText;
    public HealthBar healthBar;
    public int respawnSeconds = 10;
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        diePanel = GameObject.Find("/Canvas/DiePanel");
        respawnText = GameObject.Find("/Canvas/DiePanel/RespawnCount").GetComponent<Text>();
        diePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(0.50f);
        }
        if(currentHealth <= 0)
        {
            justDie();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Index_Proximal_L") TakeDamage(1f);
    }

    private void justDie()
    {
        diePanel.SetActive(true);
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);
        showSeconds(seconds);
        if(respawnSeconds - seconds == 0)
        {
            timer = 0f;
            diePanel.SetActive(false);
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void showSeconds(int seconds)
    {
        respawnText.text = "" +(respawnSeconds - seconds);
    }
}
