using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    private int countPlayer;

    // Start is called before the first frame update
    void Start()
    {
        countPlayer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            countPlayer++;
            if (countPlayer == 3)
            {
                Debug.Log("Livello Concluso! Congratulazioni!");
            }
        }
    }
}
