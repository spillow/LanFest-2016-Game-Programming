using UnityEngine;
using System.Collections;
using Prototype.NetworkLobby;
using UnityEngine.Networking;

public class CustomLobbyHook : LobbyHook
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        Debug.Log("scene loaded for player!");
        var playerInfo = lobbyPlayer.GetComponent<LobbyPlayer>();
        var carParts = gamePlayer.GetComponent<CarParts>();

        carParts.m_Color = playerInfo.playerColor;
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
