using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInputField;

    public RoomItem roomItemPrefab;
    List<RoomItem> roomItemsList = new List<RoomItem>();
    public Transform contentObject;

    public float timeBetweenUpdates = 1.5f;
    private float nextUpdateTime;

    //public GameObject lobbyPanel;
    //public GameObject roomPanel;
    //public List<PlayerItem> playerItemsList = new List<PlayerItem>();
    //public PlayerItem playerItemPrefabs;
    //public Transform playerItemParent;

    private void Start() {
        PhotonNetwork.JoinLobby();
    }

    public void JoinRoom(string roomName) {
        PhotonNetwork.JoinRoom(roomName);
    }

    private void UpdateRoomList(List<RoomInfo> list) {
        foreach (RoomItem item in roomItemsList) {
            Destroy(item.gameObject);
        }
        roomItemsList.Clear();

        foreach (RoomInfo room in list) {
            RoomItem newRoom = Instantiate(roomItemPrefab, contentObject);
            newRoom.SetRoomName(room.Name);
            roomItemsList.Add(newRoom);
        }
    }

    // Photon on changed
    public override void OnJoinedRoom() {
        //lobbyPanel.SetActive(false);
        //roomPanel.SetActive(true);
        //roomName.text = "Room Name : " + PhotonNetwork.CurrentRoom.Name;

        Debug.Log("Room Name : " + PhotonNetwork.CurrentRoom.Name);

        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList) {
        if (Time.time >= nextUpdateTime) {
            UpdateRoomList(roomList);
            nextUpdateTime = Time.time + timeBetweenUpdates;
        }
    }

    //public override void OnConnectedToMaster() {
    //    PhotonNetwork.JoinLobby();
    //}

    // On Click Methods
    public void OnClickCreate() {
        if (roomInputField.text.Length >= 1) {
            PhotonNetwork.CreateRoom(roomInputField.text, new RoomOptions() { MaxPlayers = 3, BroadcastPropsChangeToAll = true });
        }
    }

    public void OnClickLeaveLobby() {   
        PhotonNetwork.LeaveLobby();
    }

}
