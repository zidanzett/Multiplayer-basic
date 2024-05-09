using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject roomPrefab;
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++){
            Debug.Log(roomList[i].Name);
            GameObject Room = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity, GameObject.Find("Content").transform);
            Room.GetComponent<Room>().roomName.text = roomList[i].Name;
        }
    }
}
