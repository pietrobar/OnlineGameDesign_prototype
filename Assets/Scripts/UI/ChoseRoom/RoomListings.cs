using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomListings : Photon.PunBehaviour
{ 
    [SerializeField]
    private Transform content;

    [SerializeField]
    private RoomListingPref roomListing;

    
    public TMPro.TMP_InputField roomNameInput;

    private List<RoomListingPref> listings = new List<RoomListingPref>();

    void Start()
    {
        PhotonNetwork.autoJoinLobby = true;
        PhotonNetwork.ConnectUsingSettings("1");
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 100), PhotonNetwork.connectionStateDetailed.ToString());
    }

    public void CreateRoomFromInput()
    {
        PhotonNetwork.CreateRoom(roomNameInput.text, new RoomOptions() { MaxPlayers=3, IsVisible=true}, null);
        StartGame();
    }
    public void StartGame()
    {
        
        
        SceneManager.LoadScene("GameScene");
    }

    /*private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected");
        
    }*/
    public override void OnReceivedRoomListUpdate()
    {
        foreach (RoomInfo info in PhotonNetwork.GetRoomList())
        {
            if (info.removedFromList)//true se una stanza e' stata rimossa
            {
                int index = listings.FindIndex(x => x._roomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            else//stanza aggiunta
            {
                RoomListingPref listing = (RoomListingPref)Instantiate(roomListing, content);
                if (listing != null && info.PlayerCount<3)
                {
                    listing.SetRoomInfo(info);
                }
            }
        }
    }

    public void OnRoomListUpdate(List<RoomInfo> roomList)//questo non funziona
    {//chiamato solo se sono in una lobby
        
        foreach (RoomInfo info in roomList)
        {
            if (info.removedFromList)//true se una stanza e' stata rimossa
            {
                int index = listings.FindIndex(x => x._roomInfo.Name == info.Name);
                if (index != -1)
                {
                    Destroy(listings[index].gameObject);
                    listings.RemoveAt(index);
                }
            }
            else//stanza aggiunta
            {
                RoomListingPref listing = (RoomListingPref)Instantiate(roomListing, content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                }
            }
        }
    }
}
