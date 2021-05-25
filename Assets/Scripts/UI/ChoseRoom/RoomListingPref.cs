using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListingPref : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI roomText;

    public static string roomName;
    public RoomInfo _roomInfo {get; private set;}

    

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        roomText.text = roomInfo.PlayerCount + ", " + roomInfo.Name;
    }

    public void OnRoomClick()
    {
        GameObject.Find("SelectedLobbyBtn").GetComponent<Button>().interactable = true;
        //TODO: conviene cambiare il colore del bottone disabilitato, di default sembra pressed
        roomName = _roomInfo.Name;
        Debug.Log(roomName);

    }
   
}
