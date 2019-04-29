using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonScript : MonoBehaviour
{
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnPoint3;
    public Transform SpawnPoint4;
    public Transform SpawnPoint5;

    public GameObject CurrentRoomLabel;

    public Camera player1cam;
    public Camera player2cam;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v0");
    }

    

    private void OnConnectedToMaster()
    {
        Debug.Log("Connected with Master");
        PhotonNetwork.JoinLobby();
    }

    void OnJoinedLobby()
    {
        RoomOptions MyRoomOptions = new RoomOptions();
        MyRoomOptions.MaxPlayers = 2;
        string room_label = CurrentRoomLabel.GetComponentInChildren<Text>().text;
        PhotonNetwork.JoinOrCreateRoom(room_label, MyRoomOptions, TypedLobby.Default);
        Debug.Log("Connected with Lobby and room:" + room_label);
    }

    void OnJoinedRoom()
    {
        if (PhotonNetwork.playerList.Length > 1)
        {
            StartCoroutine(SpawnMyPlayer2());
            StartCoroutine(SpawnPuck());
            StartCoroutine(SpawnGoals());
        }
        else
        {
            StartCoroutine(SpawnMyPlayer());
        }
    }

    IEnumerator SpawnGoals()
    {
        yield return new WaitForSeconds(1);
        player2cam.enabled = false;
        player1cam.enabled = true;
        GameObject MyGoal1 = PhotonNetwork.Instantiate("Bound 1_goal", SpawnPoint4.position, SpawnPoint4.rotation, 0) as GameObject;
        GameObject MyGoal2 = PhotonNetwork.Instantiate("Bound 2_goal", SpawnPoint5.position, SpawnPoint5.rotation, 0) as GameObject;

    }

    IEnumerator SpawnPuck()
    {
        yield return new WaitForSeconds(1);
        player2cam.enabled = false;
        player1cam.enabled = true;
        GameObject MyPlayer = PhotonNetwork.Instantiate("Puck", SpawnPoint3.position, SpawnPoint3.rotation, 0) as GameObject;
    }
    
    IEnumerator SpawnMyPlayer()
    {
        yield return new WaitForSeconds(1);
        player2cam.enabled = false;
        player1cam.enabled = true;
        GameObject MyPlayer = PhotonNetwork.Instantiate("Air Hockey Paddle", SpawnPoint1.position, SpawnPoint1.rotation, 0) as GameObject;
    }

    IEnumerator SpawnMyPlayer2()
    {
        yield return new WaitForSeconds(1);
        player1cam.enabled = false;
        player2cam.enabled = true;
        GameObject MyPlayer = PhotonNetwork.Instantiate("Air Hockey Paddle 2", SpawnPoint2.position, SpawnPoint1.rotation, 0) as GameObject;
    }
}
