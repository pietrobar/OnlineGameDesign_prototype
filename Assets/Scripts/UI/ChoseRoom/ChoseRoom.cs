using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseRoom : MonoBehaviour
{

    
    public void JoinRoomAndStart()
    {
        string rn = RoomListingPref.roomName;
        PhotonNetwork.JoinRoom(rn);
        SceneManager.LoadScene("GameScene");

    }
}
