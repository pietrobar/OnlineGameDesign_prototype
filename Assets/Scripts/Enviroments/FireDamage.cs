using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDamage : MonoBehaviour
{
    private float timer = 0.0f;

    public float fireDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<HeroHealth>().TakeDamage(fireDamage);
            timer = 0.0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (timer >= 2f)
            {
                other.gameObject.GetComponent<HeroHealth>().TakeDamage(fireDamage);
                timer = 0.0f;
            }
        }
    }
}
