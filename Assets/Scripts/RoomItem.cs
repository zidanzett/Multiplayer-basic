using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomItem : MonoBehaviour
{
    public TextMeshProUGUI roomName;
    private LobbyManager manager;

    private void Start() {
        manager = FindObjectOfType<LobbyManager>();
    }

    public void SetRoomName(string name) {
        roomName.text = name;
    }

    public void OnClickItem() {
        manager.JoinRoom(roomName.text);
    }
}
