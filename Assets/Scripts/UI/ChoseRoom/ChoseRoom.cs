using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoseRoom : MonoBehaviour
{

    
    public void JoinRoomAndStart()
    {
        string rn = RoomListingPref.roomName;
        Debug.Log(rn);
        PhotonNetwork.JoinRoom(rn);//TODO:controllare che non ci siano gia' 3 giocatori
        SceneManager.LoadScene("GameScene");

    }
}
