using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    public Text roomName;
    public void JoinRoom(){
        GameObject.Find("CreateAndJoin").GetComponent<CreateAndJoin>().JoinRoom(roomName.text);
    }
}
