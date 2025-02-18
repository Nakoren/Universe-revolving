using System;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Icons levelIcons;
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
            activeRoomController.onRoomChange -= OnLoadRequest;
            Destroy(activeRoom);
        }
        Room newRoom = levelMap[layer][ind];
        if (newRoom.prefab != null)
        {
            activeRoom = Instantiate(newRoom.prefab);
            activeRoomController = activeRoom.GetComponentInChildren<RoomController>();
        }
        Vector3 startLocation = activeRoomController.startPosition.position;
        Debug.Log($"Warping player to {startLocation}");
        player.Warp(startLocation);

        activeRoomController.Initialize(GetNextLayerRooms(), player, levelIcons);
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
