using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characterPrefab;

    public GameObject panelSetting;
    public GameObject panelPlay;
    public GameObject diePanel;
    public GameObject endLevelPanel;
    public GameObject newsPaperPanel;
    public Text respawnCounter;

    public GameObject _player;
    
    public Transform spawnPoint;

    public static bool inGame=true;

    private GameObject[] instantiatedPlayers = new GameObject[3];

    private GameObject myPlayer;

    
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
        _player = characterPrefab[characterIndex];
        instantiatedPlayers[characterIndex]=PhotonNetwork.Instantiate(characterPrefab[characterIndex].name, spawnPoint.position, spawnPoint.rotation, 0);

        
        ExitGames.Client.Photon.Hashtable currentHt = PhotonNetwork.room.CustomProperties;
        
        currentHt.Add(ChoseCharacter.instance.characterIndex.ToString(), "giocatore presente");
        PhotonNetwork.room.SetCustomProperties(currentHt);

        myPlayer = instantiatedPlayers[characterIndex];
        
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
        panelSetting.SetActive(false);
        panelPlay.SetActive(false);
        EnemyHealth.enemiesKill = 0;
        Newspaper.newspaperCount = 0;
        PanelEXP.valueAttack = 0;
        PanelEXP.valueHealth = 0;
        PanelEXP.valueSpeed = 0;
        CountXP.xp = 0;
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("CharacterSelect");
        //Application.Quit(); non deve uscire dal gioco
    }

    public float GetAttackBarValue()
    {
        if (panelSetting)
        {
            return GameObject.Find("Attack Bar").GetComponent<Slider>().value;
        }
        else
        {
            return 0;
        }
    }

    public float GetHealtBarValue()
    {
        if (panelSetting)
        {
            return GameObject.Find("Healt Bar").GetComponent<Slider>().value;
        }
        else
        {
            return 0;
        }
    }

    public float GetSpeedBarValue()
    {
        if (panelSetting)
        {
            return GameObject.Find("Speed Bar").GetComponent<Slider>().value;
        }
        else
        {
            return 0;
        }
    }

    public GameObject GetMyPlayer()
    {
        return this.myPlayer;
    }

    public void ShowNewspaper(GameObject playerWhoCollided)
    {
        Debug.Log(playerWhoCollided.name + " " + _player.name);
        if(playerWhoCollided.name.Contains(_player.name))
        {
            newsPaperPanel.SetActive(true);
            inGame = false;//la variabile inGame e' usata negli script dei giocatori per non permettere movimenti
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void CloseNewspaper()
    {
        inGame = true;//la variabile inGame e' usata negli script dei giocatori per non permettere movimenti
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        newsPaperPanel.SetActive(false);
    }
}
