using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    public GameObject optionsPanel;

    
    private int characterIndex=0;


    public void changeCharacter()
    {
        for(int i = 0; i < characters.Length; i++)//fa scomparire tutti i character
        {
            characters[i].SetActive(false);
        }
        //fa ricomparire solo quello giusto
        this.characterIndex = (this.characterIndex+1)%3;
        characters[this.characterIndex].SetActive(true);
    }

    public void StarGame()
    {
        SceneManager.LoadScene("GameScene");

        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
    }

    public void options()
    {
        optionsPanel.SetActive(true);
    }

    public void backFromOptionPanel()
    {
        optionsPanel.SetActive(false);
    }
}
