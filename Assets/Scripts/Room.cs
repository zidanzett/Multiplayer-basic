using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI roomName;
    public void JoinRoom(){
        GameObject.Find("CreateAndJoin").GetComponent<CreateAndJoin>().JoinRoom(roomName.text);
    }
}
