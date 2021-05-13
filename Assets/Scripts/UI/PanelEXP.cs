using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelEXP : MonoBehaviour
{

    public Text totEXPText;

    public Button AttackButton;
    public Button HealtButton;
    public Button SpeedButton;

    private int TotEXP;

    private int xpunity = 3;
    private int xpAttack;
    private int xpSpeed;
    private int xpHealth;

    public Slider attackBar;
    public Slider healtBar;
    public Slider speedBar;

    public static float valueAttack = 0;
    public static int valueHealth = 0;
    public static int valueSpeed = 0;

    void Start()
    {
        xpAttack = xpunity;
        xpSpeed = xpunity;
        xpHealth = xpunity;
    }

    void Update()
    {
        TotEXP = CountXP.getXP();
        bool availableXP = TotEXP >= xpunity;
        AttackButton.interactable = availableXP;
        HealtButton.interactable = availableXP;
        SpeedButton.interactable = availableXP;
    }

    public void SetSlider(int n, Slider bar)
    {
        if (bar == attackBar)
        {
            attackBar.value += n;
            valueAttack += n;
        }
        else if (bar == healtBar)
        {
            healtBar.value += n;
            valueHealth += n;
        }
        else if (bar == speedBar)
        {
            speedBar.value += n;
            valueSpeed += n;
        }
    }

    public void ButtonAttack()
    {
        CountXP.setXP(-xpAttack);
        TotEXP = CountXP.getXP();
        SetSlider(xpunity, attackBar);
        xpAttack += 3;
    }

    public void ButtonHealt()
    {
        CountXP.setXP(-xpHealth);
        TotEXP = CountXP.getXP();
        SetSlider(xpunity, healtBar);
        xpHealth += 3;
    }

    public void ButtonSpeed()
    {
        CountXP.setXP(-xpSpeed);
        TotEXP = CountXP.getXP();
        SetSlider(xpunity, speedBar);
        xpSpeed += 3;
    }

}