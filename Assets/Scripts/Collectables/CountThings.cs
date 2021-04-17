using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountThings : MonoBehaviour
{
    public int all;
    private Text label;
    private int n;

    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        label.text = "Newspaper: " + Newspaper.newspaperCount + "/" + all;
    }

    /*public void AddCount()
    {
        n++;
    }*/


}
