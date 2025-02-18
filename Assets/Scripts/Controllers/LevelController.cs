using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Icons levelIcons;
    [SerializeField] int nextSceneIndex;
    MapGenerator mapGenerator;

    List<List<Room>> levelMap;
    GameObject activeRoom;
    RoomController activeRoomController;
    int currentLayer = 0;

    public Action<int> onRoomChange;

    private void Awake()
    {
        if (player == null)
        {
            GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
            if (playerGO != null)
            {
                player = playerGO.GetComponent<Player>();
            }
        }
        mapGenerator = GetComponent<MapGenerator>();
    }

    private void Start()
    {
        UpdateMap();
        LoadNextStage(0);
    }

    public void UpdateMap()
    {
        levelMap = mapGenerator.GenerateMapWithGlobalPool();
    }

    private void LoadNextStage(int ind)
    {
        if (activeRoom != null)
        {
            activeRoomController.onRoomChange -= OnLoadRequest;
            Destroy(activeRoom);
        }

        Room newRoom = levelMap[currentLayer][ind];
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
        activeRoomController.onFinalRoomChange += LoadNextLevel;
    } 

    private void OnLoadRequest(int ind)
    {
        currentLayer += 1;
        LoadNextStage(ind);
    }

    private List<Room> GetNextLayerRooms()
    {
        if (currentLayer == levelMap.Count - 1) { return new List<Room>(); }
        return levelMap[currentLayer + 1];
    }

    private void LoadNextLevel()
    {
        DontDestroyOnLoad(player);
        SceneManager.LoadScene(nextSceneIndex);
    }
}
