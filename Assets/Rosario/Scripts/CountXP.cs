using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountXP : MonoBehaviour
{
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
        label.text = "XP: " + n;
    }

    public void AddXP(int amount)
    {
        n+=amount;
    }
}
