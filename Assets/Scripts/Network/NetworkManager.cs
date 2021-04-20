using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : Photon.MonoBehaviour
{
    public Transform spawnPoint;
    private RoomInfo[] rooms;
    // Start is called before the first frame update
    /*void Start()
    {
        PhotonNetwork.autoJoinLobby = true;
        PhotonNetwork.ConnectUsingSettings("1");
    }
*/
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), PhotonNetwork.connectionStateDetailed.ToString());
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom("Stanza1");
    }

    void OnJoinedRoom()
    {
        //instanzio il giocatore
        PhotonNetwork.Instantiate("Magician", spawnPoint.position, spawnPoint.rotation, 0);
    }
}
