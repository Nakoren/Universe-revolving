using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    [Header("Generation settings")]
    [SerializeField] public int levelSize;
    [SerializeField] public int minRoomCountPerLayer = 1;
    [SerializeField] public int maxRoomCountPerLayer = 3;
    [SerializeField] public int? fixedShopLevel = null;
    [SerializeField] public bool shopSoloLayer = false;
    [SerializeField] public int? shopRoomsPerLevel = 1;
    [SerializeField] public int? rewardRoomsPerLevel = 1;

    [Header("Rooms")]
    [SerializeField] public Room startRoom;
    [SerializeField] public BattleRoom[] battleRoomList;
    [SerializeField] public RewardRoom[] rewardRoomList;
    [SerializeField] public ShopRoom[] shopRoomList;
    [SerializeField] public BossRoom[] bossRoomList;

    private List<List<Room>> map;

    private int totalWeight = 0;
    private List<Room> randomRooms = new List<Room>();
    
    public void GenerateMap()
    {
        if (map != null)
        {
            ClearMap();
        }
        map = new List<List<Room>>();
        map.Add(new List<Room>());
        map[0].Add(startRoom);

        for(int layer = 0; layer < levelSize - 1; layer++)
        {
            int layerRoomCount = Random.Range(minRoomCountPerLayer, maxRoomCountPerLayer+1);
            for(int room = 0; room < layerRoomCount; room++)
            {
                
            }
        }
    }

    public void Start()
    {
        randomRooms.AddRange(randomRooms);
        if (rewardRoomsPerLevel == null)
        {
            randomRooms.AddRange(rewardRoomList);
        }
        if ((fixedShopLevel == null)||(shopRoomsPerLevel==null))
        {
            randomRooms.AddRange(shopRoomList);
        }
    }

    public void ProjectMap()
    {

    }

    public void ClearMap()
    {
        foreach (List<Room> layer in map)
        {
            foreach(Room room in layer)
            {
                Destroy(room);
            }
        }
    }
}
