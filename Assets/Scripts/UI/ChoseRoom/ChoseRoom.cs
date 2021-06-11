using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoseRoom : MonoBehaviour
{
    public GameObject choseCharacterPanel;
    public GameObject choseRoomPanel;

    public void JoinRoomAndStart()
    {
        string rn = RoomListingPref.roomName;
        PhotonNetwork.JoinRoom(rn);
        SceneManager.LoadScene("GameScene");

    }

    public void BackToChoseCharacter()
    {
        choseRoomPanel.SetActive(false);
        choseCharacterPanel.SetActive(true);
    }
}
