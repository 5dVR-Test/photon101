using Photon.Pun;
using UnityEngine;


public class RoomManager : MonoBehaviourPunCallbacks
{

    public GameObject player;

    [Space]
    public Transform spawnPoint;



    private void Start()
    {
        Debug.Log("Connecting...");

        _ = PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        Debug.Log("Connected to Server");


        _ = PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();

        Debug.Log("We're conneted and in lobby");

        _ = PhotonNetwork.JoinOrCreateRoom("LazyGame", null, null);


    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Debug.Log("We're conneted and in room");

        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);

        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
    }

}
