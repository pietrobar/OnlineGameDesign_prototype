using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDamage : MonoBehaviour
{
    private float timer = 0.0f;

    public float acidDamage = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            other.gameObject.GetComponent<HeroHealth>().TakeDamage(acidDamage);
            timer = 0.0f;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            if (timer >= 2f)
            {
                other.gameObject.GetComponent<HeroHealth>().TakeDamage(acidDamage);
                timer = 0.0f;
            }
        }
    }
}
