using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomListingPref : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI roomText;

    public RoomInfo _roomInfo {get; private set;}

    

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        roomText.text = roomInfo.MaxPlayers + ", " + roomInfo.Name;
    }
   
}
