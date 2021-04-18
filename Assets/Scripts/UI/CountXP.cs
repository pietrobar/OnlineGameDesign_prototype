using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountXP : MonoBehaviour
{
    private Text label;
    private static int xp;

    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        label.text = "XP: " + xp;
    }

    public static void setXP(int amount)
    {
        xp+=amount;
    }
}
