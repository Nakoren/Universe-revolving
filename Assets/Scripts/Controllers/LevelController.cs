using System;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] Player player;
    MapGenerator mapGenerator;

    List<List<Room>> levelMap;
    GameObject activeRoom;
    RoomController activeRoomController;
    int currentLayer = 0;

    public Action<int> onRoomChange;

    private void Awake()
    {
        mapGenerator = GetComponent<MapGenerator>();
    }

    private void Start()
    {
        UpdateMap();
        LoadRoom(0, 0);
    }

    public void UpdateMap()
    {
        levelMap = mapGenerator.GenerateMapWithGlobalPool();
    }

    private void LoadRoom(int layer, int ind)
    {
        if (activeRoom != null) {
            Destroy(activeRoom);
        }
        Room newRoom = levelMap[layer][ind];
        activeRoom = Instantiate(newRoom.prefab);
        activeRoomController = activeRoom.GetComponent<RoomController>();
        player.Warp(activeRoomController.startPosition.position);
        Debug.Log(player.gameObject.transform.position);

        activeRoomController.Initialize(GetNextLayerRooms());
        activeRoomController.onRoomChange += OnLoadRequest;
    }

    private void OnLoadRequest(int ind)
    {
        currentLayer += 1;
        LoadRoom(currentLayer, ind);
    }

    private List<Room> GetNextLayerRooms()
    {
        if (currentLayer == levelMap.Count - 1) { return new List<Room>(); }
        
        return levelMap[currentLayer+1];
    }
}
