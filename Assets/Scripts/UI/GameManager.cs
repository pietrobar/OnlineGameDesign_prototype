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
    
    void Start()
    {
        LoadCharacter();
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

    private void LoadCharacter()
    {
        int characterIndex = PlayerPrefs.GetInt("CharacterIndex");
        _player = Instantiate(characterPrefab[characterIndex]);
    }

    public void ButtonSetting()
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
        //TODO: si deve uscire dal gioco come in john lemon
    }
}
