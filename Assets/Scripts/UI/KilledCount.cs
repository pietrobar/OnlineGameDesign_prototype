﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KilledCount : MonoBehaviour
{
    private Text label;

    // Start is called before the first frame update
    void Start()
    {
        label = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        label.text = "Enemis Killed: " + EnemyHealth.enemiesKill;
    }
}
