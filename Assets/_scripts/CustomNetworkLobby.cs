using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CustomNetworkLobby : NetworkLobbyManager
{
    public void OnHostGame()
    {
        //ConnectionConfig config;
        var NC = StartHost();
        this.TryToAddPlayer();
        /*
        var player = (GameObject)Instantiate(
            gamePlayerPrefab,
            Vector3.zero,
            Quaternion.identity);
        NetworkServer.Spawn(player);
        */
        //this.start
        Debug.Log("trying to host!");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
