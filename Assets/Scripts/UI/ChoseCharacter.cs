using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseCharacter : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characters;
    public GameObject optionsPanel;
    public GameObject choseRoomPanel;

    
    
    private int characterIndex=0;//per fare in modo che il primo character selezionato sia quello in posizione 0 lo metto di default nello start


    public void changeCharacter()
    {
        
        for(int i = 0; i < characters.Length; i++)//fa scomparire tutti i character
        {
            characters[i].SetActive(false);
        }
        //fa ricomparire solo quello giusto
        this.characterIndex = (this.characterIndex+1)%3;
        characters[this.characterIndex].SetActive(true);//rendo visibile solo quello giusto

        PlayerPrefs.SetInt("CharacterIndex", characterIndex);
    }

    public void FromChoseCaracterPanelToRoomChosingPanel()
    {
        //choseCharacterPanel.SetActive(false);
        this.gameObject.SetActive(false);//funziona al posto della riga precedente?
        choseRoomPanel.SetActive(true);

    }
    private void Start()
    {
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);//di default e' 0, se faccio change character lo cambio

    }

    public void StarGame()
    {
        SceneManager.LoadScene("GameScene");
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
