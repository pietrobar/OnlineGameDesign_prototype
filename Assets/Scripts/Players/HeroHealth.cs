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
    private Animator animator;
    private float increaseHealtXP;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        diePanel = GameManager.instance.diePanel;
        respawnText = GameManager.instance.respawnCounter;
    
        animator = GetComponent<Animator>();
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
        if (PanelEXP.valueHealth != 0)
        {
            currentHealth -= damage / (PanelEXP.valueHealth/2);
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Index_Proximal_L" && collision.collider.gameObject.transform.root.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack02"))//index proximal l e' il pugno sinistro del golem
        {
            //controllo ulteriormente che se il giocatore in questione e' il soldato e sta facendo l'animazione di difesa non deve farsi male
            if (GameManager.instance.GetInstantiatedPlayers()[2] != null && GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Defense"))
            {
                //non prendo dammaggio dato che mi sto parando e sono il soldato
                //qui si potrebbe aggiungere un eventuale audio di colpo sullo scudo
            }
            else
            {
                TakeDamage(1f);
            }

        }
    }

    private void justDie()
    {
        GameManager.inGame = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        animator.SetBool("dying", true);
        diePanel.SetActive(true);
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);
        showSeconds(seconds);
        if(respawnSeconds - seconds == 0)
        {
            animator.SetBool("dying", false);

            timer = 0f;
            diePanel.SetActive(false);
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);

            GameManager.inGame = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            transform.position = new Vector3(-17.03425f, 1.346912f, -25.41615f); // in futuro dovrà essere la posizione di un altro player
        }
    }

    private void showSeconds(int seconds)
    {
        respawnText.text = "" +(respawnSeconds - seconds);
    }

    public float GetHealtValueXP()
    {
        return increaseHealtXP = GetComponent<GameManager>().GetHealtBarValue();
    }
}
