using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Newspaper : MonoBehaviour
{
    public static int newspaperCount=0;
    public float speedRotation = 25f;

    public Text labelNewspaper;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right * speedRotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //labelNewspaper = GameObject.Find("NewspaperCount").GetComponent<Text>();
        if (other.tag == "Player")
        {
            //labelNewspaper.GetComponent<CountThings>().AddCount();
            newspaperCount++;
            Destroy(gameObject);
        }
    }
}
