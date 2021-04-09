using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject choseCharacterPanel;
    public GameObject playGamePanel;
    public void PlayButton()
    {
        choseCharacterPanel.SetActive(true);
        playGamePanel.SetActive(false);
    }

    public void QuitButton()
    {
        //TODO: si deve uscire dall'applicazione
        Debug.Log("Quit");
    }

}
