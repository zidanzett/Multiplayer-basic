using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoin : MonoBehaviourPunCallbacks
{
    public TMP_InputField createInputField;

    private string gameScene = "Game";

    public void CreateRoom(){
        PhotonNetwork.CreateRoom(createInputField.text);
    }    

    // public void JoinRoom(){
    //     PhotonNetwork.JoinRoom(joinInputField.text);
    // }

    public void JoinRoom(string roomName){
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel(gameScene);
    }
}
