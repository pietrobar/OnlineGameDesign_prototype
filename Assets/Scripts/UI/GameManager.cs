using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characterPrefab;

    public GameObject panelSetting;
    public GameObject panelPlay;

    private GameObject _player;

    public Transform spawnPoint;

    public static bool inGame=true;

    private GameObject[] instantiatedPlayers = new GameObject[3];


    
    public static GameManager instance;

    private void Awake()
    {
        inGame = true;
        instance = this;
    }

    

    public GameObject[] GetInstantiatedPlayers()
    {
        return instantiatedPlayers;
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), PhotonNetwork.connectionStateDetailed.ToString());
    }

   


    void OnJoinedRoom()
    {
        //instanzio il giocatore
        int characterIndex = PlayerPrefs.GetInt("CharacterIndex");
        instantiatedPlayers[characterIndex]=PhotonNetwork.Instantiate(characterPrefab[characterIndex].name, spawnPoint.position, spawnPoint.rotation, 0);
    }


    void Update()
    {

        //voglio controllare se il giocatore preme Esc e in caso disabilitare il controllo del gioco
        if (Input.GetKey(KeyCode.Escape))
        {
            inGame = false;//la variabile inGame e' usata negli script dei giocatori per non permettere movimenti
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            ButtonSetting();
        }
        
    }

 

    public void ButtonSetting()//rotella
    {
        panelSetting.SetActive(true);

    }

    public void ButtonExit()
    {
        panelSetting.SetActive(false);
        //devo ritornare in game:
        inGame = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ButtonQuit()
    {
        Destroy(_player);
        panelSetting.SetActive(false);
        panelPlay.SetActive(false);
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("CharacterSelect");
        //Application.Quit(); non deve uscire dal gioco
    }

    
}
