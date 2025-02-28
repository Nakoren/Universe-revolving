using NUnit.Framework;
using UnityEngine;

public class ShopRoomController : RoomController
{
    [SerializeField] Transform[] shopItemsPositions;
    [SerializeField] PartsDB partsDB;
    [SerializeField] static HealPickUp healItem;
    [Header("Chances for spawning items if different rarity (0 - 100)")]
    [SerializeField] int commonChance;
    [SerializeField] int unCommonChance;
    [SerializeField] int rareChance;
    [SerializeField] int epicChance;
    [SerializeField] int legendaryChance;

    private void Awake()
    {
        if (commonChance < 0) { commonChance = 0; }
        if (commonChance > 100) { commonChance = 100; }
        if (unCommonChance < 0) { unCommonChance = 0; }
        if (unCommonChance > 100) { unCommonChance = 100; }
        if (rareChance < 0) { rareChance = 0; }
        if (rareChance > 100) { rareChance = 100; }
        if (epicChance < 0) { epicChance = 0; }
        if (epicChance > 100) { epicChance = 100; }
        if (legendaryChance < 0) { legendaryChance = 0; }
        if (legendaryChance > 100) { legendaryChance = 100; }
    }

    protected override void SpecProcessing()
    {
        base.SpecProcessing();
        foreach(Transform spawnPosition in shopItemsPositions)
        {
            int rarityIndex = GetRarityIndex();
            if (rarityIndex >= 0)
            {
                Item itemToSpawn = partsDB.GetRandomItemOfRarity(rarityIndex);
            }
            else
            {
                
            }
        }
    }
    private int GetRarityIndex()
    {
        int rarityIndex = -1;
        int random = UnityEngine.Random.Range(0, 100);
        if (random <= legendaryChance) rarityIndex = 4;
        else
        {
            if (random <= epicChance) rarityIndex = 3;
            else
            {
                if (random <= rareChance) rarityIndex = 2;
                else
                {
                    if (random <= unCommonChance) rarityIndex = 1;
                    else
                    {
                        if (random <= commonChance) rarityIndex = 0;
                    }
                }
            }
        }
        return rarityIndex;
    }
}
