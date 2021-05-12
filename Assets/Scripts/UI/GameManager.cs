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

    private GameObject _player;

    public Transform spawnPoint;


    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), PhotonNetwork.connectionStateDetailed.ToString());
    }

   


    void OnJoinedRoom()
    {
        //instanzio il giocatore
        int characterIndex = PlayerPrefs.GetInt("CharacterIndex");
        PhotonNetwork.Instantiate(characterPrefab[characterIndex].name, spawnPoint.position, spawnPoint.rotation, 0);
    }


    void Update()
    {
        if (panelSetting == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                panelSetting.SetActive(false);
            }

        }
    }

 

    public void ButtonSetting()//rotella
    {
        panelSetting.SetActive(true);
    }

    public void ButtonExit()
    {
        panelSetting.SetActive(false);
    }

    public void ButtonQuit()
    {
        Destroy(_player);
        panelSetting.SetActive(false);
        panelPlay.SetActive(false);
        Application.Quit();
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
}
