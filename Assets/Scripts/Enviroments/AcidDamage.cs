using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDamage : MonoBehaviour
{
    private float timer = 0.0f;

    public float acidDamage = 2f;

    //AUDIO
    public AudioSource acidBurd;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            acidBurd.Play();
            if (other.gameObject.GetComponent<HeroHealth>())
            {
                other.gameObject.GetComponent<HeroHealth>().TakeDamage(acidDamage);
                timer = 0.0f;
            }
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            if (other.gameObject.GetComponent<HeroHealth>())
            {
                if (timer >= 2f)
                {
                    other.gameObject.GetComponent<HeroHealth>().TakeDamage(acidDamage);
                    timer = 0.0f;
                }
            }
        }
    }
}
