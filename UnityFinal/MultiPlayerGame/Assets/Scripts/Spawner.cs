using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SocketIO;

public class Spawner : MonoBehaviour {
    public GameObject localPlayer;
    public GameObject playerPrefab;
    public SocketIOComponent socket;
    public int score;

    Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();

    public GameObject SpawnPlayer(string id) {
        var player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        id = id.Replace("\"", "");
        player.GetComponent<NetworkEntity>().id = id;
        player.GetComponent<NetworkEntity>().score = 0;
        AddPlayer(id, player);
        return player;
    }

    public void AddPlayer(string id, GameObject player)
    {
        id = id.Replace("\"", "");
        players.Add(id, player);
    }

    public GameObject FindPlayer(string id)
    {
        id = id.Replace("\"", "");
        return players[id];
    }

    public void RemovePlayer(string id)
    {
        id = id.Replace("\"", "");
        var player = players[id];

        Destroy(player);
        players.Remove(id);
    }

    public int ReturnScore(string id)
    {
        id = id.Replace("/", "");
        var player = players[id];
        return player.GetComponent<NetworkEntity>().score;
    }

}
