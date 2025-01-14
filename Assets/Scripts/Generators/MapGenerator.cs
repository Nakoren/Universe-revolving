using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Jobs;

public class RoomGenerator : MonoBehaviour
{
    [Header("Generation settings")]
    [SerializeField] public int levelSize;
    [SerializeField] public int minRoomCountPerLayer = 1;
    [SerializeField] public int maxRoomCountPerLayer = 3;
    [Header("Warning: fixed shop level will override multiple shops per level paramater")]
    [SerializeField] public int fixedShopLevel;
    [SerializeField] public bool shopSoloLayer = false;
    [Header("This paramaters will force specific rooms to spawn in specific count\nOtherwise their spawn will be totally random")]
    [Header("Warning: if there is not enough space to spawn specified amount of rooms,\nthey will have priority in relative order")]
    [SerializeField] public int rewardRoomsPerLevel = 1;
    [SerializeField] public int shopRoomsPerLevel = 1;
    [SerializeField] public int restRoomsPerLevel = 1;
    [Header("Warning:\nIf there is not enough rooms to build a level\nduplicates still will be created")]
    [SerializeField] public bool UniqueRooms = false;

    [Header("Rooms")]
    [SerializeField] public Room startRoom;
    [SerializeField] public BattleRoom[] battleRoomList;
    [SerializeField] public RewardRoom[] rewardRoomList;
    [SerializeField] public RestRoom[] restRoomList;
    [SerializeField] public ShopRoom[] shopRoomList;
    [SerializeField] public BossRoom[] bossRoomList;
    
    enum roomType {start ,battle, reward, rest, shop, boss}

    private List<List<Room>> map;

    private int totalWeight = 0;
    private List<int[]> battleRoomPositions = new List<int[]>();
    private List<Room> randomRooms = new List<Room>();

    public void Start()
    {
        GenerateRandomRoomsList();
    }

    public void GenerateMap()
    {
        if (map != null)
        {
            ClearMap();
        }
        GenerateRandomRoomsList();

        map = new List<List<Room>>();
        for (int t = 0; t < levelSize; t++)
        {
            map.Add(new List<Room>());
        }

        AddRoomToEnd(startRoom, 0);
        
        //Filling level with rooms from list
        for(int layerNum = 1; layerNum<map.Count-1;layerNum++)
        {
            Debug.Log("Generating level " + layerNum);
            if ((fixedShopLevel != 0) && (layerNum == fixedShopLevel))
            {
                ShopRoom shopRoom = shopRoomList[Random.Range(0, shopRoomList.Length)];
                int shopIndex = Random.Range(0, map[layerNum].Count);
                if (!shopSoloLayer)
                {
                    int layerRoomCount = Random.Range(minRoomCountPerLayer, maxRoomCountPerLayer + 1) - 1;
                    for (int room = 0; room < layerRoomCount; room++)
                    {
                        AddRoomToEnd(SelectRandomRoomFromList(), layerNum);
                    }
                    AddRoomToIndex(shopRoom, layerNum, shopIndex);
                }
                else
                {
                    AddRoomToIndex(shopRoom, layerNum, shopIndex);
                }
            }
            else
            {
                int layerRoomCount = Random.Range(minRoomCountPerLayer, maxRoomCountPerLayer + 1);
                for (int room = 0; room < layerRoomCount; room++)
                {
                    AddRoomToEnd(SelectRandomRoomFromList(), layerNum);
                }
            }
        }

        map[map.Count - 1].Add(bossRoomList[Random.Range(0,bossRoomList.Length)]);

        //Replacing rooms
        DebugLogMap();
        DebugBattleRooms();
        if (rewardRoomsPerLevel != -1)
        {
            replaceBattleRooms((int)rewardRoomsPerLevel, rewardRoomList);
        }
        if (!(fixedShopLevel > 0) && (shopRoomsPerLevel != -1))
        {
            replaceBattleRooms((int)shopRoomsPerLevel, shopRoomList);
        }
        if (restRoomsPerLevel != -1)
        {
            replaceBattleRooms((int)restRoomsPerLevel, restRoomList);
        }
        DebugLogMap();
    }

    private void AddRoomToEnd(Room room, int layerNum)
    {
        map[layerNum].Add(room);
        if (room is BattleRoom)
        {
            int[] t = { layerNum, map[layerNum].Count-1 };
            battleRoomPositions.Add(t);
        }
        if ((UniqueRooms)&&(randomRooms.Contains(room)))
        {
            randomRooms.Remove(room);
            totalWeight -= room.weight;
            if (randomRooms.Count == 0)
            {
                GenerateRandomRoomsList();
            }
        }
        DebugArray<Room>(randomRooms);
    }

    private void AddRoomToIndex(Room room, int layerNum, int indexOnLayer)
    {
        map[layerNum].Insert(indexOnLayer, room);
        if (room is BattleRoom)
        {
            int[] t = { layerNum, indexOnLayer };
            battleRoomPositions.Add(t);
        }
        if (UniqueRooms)
        {
            randomRooms.Remove(room);
            totalWeight -= room.weight;
            if (randomRooms.Count == 0)
            {
                GenerateRandomRoomsList();
            }
        }
    }

    private void replaceBattleRooms(int count, Room[] rooms)
    {
        for(int i = 0;i<count; i++)
        {
            if (battleRoomPositions.Count <= 0) { return; }
            int randomBattleRoomInd = Random.Range(0, battleRoomPositions.Count);
            int[] replaceRoomIndex = battleRoomPositions[randomBattleRoomInd];
            battleRoomPositions.Remove(replaceRoomIndex);
            //Debug.Log("Replacing at " + replaceRoomIndex[0]+" " + replaceRoomIndex[1]);
            map[replaceRoomIndex[0]][replaceRoomIndex[1]] = rooms[Random.Range(0, rooms.Length)];
        }
    }

    private void GenerateRandomRoomsList()
    {
        randomRooms = new List<Room>();
        randomRooms.AddRange(battleRoomList);
        if (rewardRoomsPerLevel == -1)
        {
            randomRooms.AddRange(rewardRoomList);
        }
        if (restRoomsPerLevel == -1)
        {
            randomRooms.AddRange(restRoomList);
        }
        if ((fixedShopLevel == -1) && (shopRoomsPerLevel == -1))
        {
            randomRooms.AddRange(shopRoomList);
        }
        totalWeight = 0;
        foreach(Room room in randomRooms)
        {
            totalWeight += room.weight;
        }
    }

    private Room SelectRandomRoomFromList()
    {
        int randomInd = Random.Range(0, totalWeight);
        int finalInd = 0;
        int localCounter = 0;
        for(int curInd = 0;curInd<randomInd;curInd++)
        {
            if(localCounter == randomRooms[finalInd].weight)
            {
                finalInd++;
                localCounter = 0;
            }
            else
            {
                localCounter++;
            }
        }
        return randomRooms[finalInd];
    }

    public void ClearMap()
    {
        /*
        foreach (List<Room> layer in map)
        {
            foreach(Room room in layer)
            {
                Destroy(room);
            }
        }
        */
        battleRoomPositions = new List<int[]>();
    }
    
    public void DebugLogMap()
    {
        string resOutput = "";
        foreach(List<Room> layer in map)
        {
            foreach(Room room in layer)
            {
                resOutput += room.name + " ";
            }
            resOutput += "\n";
        }
        Debug.Log(resOutput);
    }

    public void DebugBattleRooms()
    {
        string output = "";
        for(int i = 0; i < battleRoomPositions.Count; i++)
        {
            output += $"[{battleRoomPositions[i][0]} {battleRoomPositions[i][1]}] ";
        }
        Debug.Log(output);
    }

    private void DebugArray<T>(List<Room> array)
    {
        string output = "";
        for (int i = 0; i < array.Count; i++)
        {
            output += $"{array[i].ToString()} ";
        }
        Debug.Log(output);
    }
}