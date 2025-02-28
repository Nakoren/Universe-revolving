    using NUnit.Framework;
using UnityEngine;

public class ShopRoomController : RoomController
{
    [SerializeField] Transform[] shopItemsPositions;
    [SerializeField] PartsDB partsDB;
    [SerializeField] GameObject healPickUp;
    [SerializeField] GameObject pickUpObject;

    [Header("Default price of items")]
    [SerializeField] public int commonBaseCost = 50;
    [SerializeField] public int rareBaseCost = 250;
    [SerializeField] public int epicBaseCost = 500;
    [SerializeField] public int legendaryBaseCost = 1000;

    [SerializeField] public int randomPriceRange = 10;
    [SerializeField] public int randomPriceStep = 0;

    [SerializeField] public int healPrice = 150;

    [Header("Chances for spawning items if different rarity (0 - 100)")]
    [SerializeField] int commonChance;
    [SerializeField] int rareChance;
    [SerializeField] int epicChance;
    [SerializeField] int legendaryChance;

    private void Awake()
    {
        if (commonChance < 0) { commonChance = 0; }
        if (commonChance > 100) { commonChance = 100; }
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
                //Instantiate(pickUpObject.gameObject, spawnPosition);
                GameObject spawn = Instantiate(pickUpObject, spawnPosition.position, spawnPosition.rotation);
                spawn.name = "PartPickUp";
                PartPickUpWithPrice compPickUpObject = spawn.GetComponent<PartPickUpWithPrice>();
                int cost = GetCost(rarityIndex);
                compPickUpObject.Price = cost;
                compPickUpObject.GetPart(itemToSpawn);
                compPickUpObject.UpdateData();
            }
            else
            {
                //Instantiate(pickUpObject.gameObject, spawnPosition);
                GameObject spawn = Instantiate(healPickUp, spawnPosition.position, spawnPosition.rotation);
                spawn.name = "HealPickUp";
                HealPickUpWithPrice compHealPickUp = spawn.GetComponent<HealPickUpWithPrice>();
                compHealPickUp.Price = healPrice;
                compHealPickUp.UpdateData();
            }
        }
    }
    private int GetRarityIndex()
    {
        int rarityIndex = -1;
        int random = UnityEngine.Random.Range(0, 100);
        if (random <= legendaryChance) rarityIndex = 3;
        else
        {
            if (random <= epicChance) rarityIndex = 2;
            else
            {
                if (random <= rareChance) rarityIndex = 1;
                else
                {
                    if (random <= commonChance) rarityIndex = 0;
                }
            }
        }
        return rarityIndex;
    }

    private int GetCost(int rarity)
    {
        int cost = 0;
        switch (rarity)
        {
            case 0: cost = commonBaseCost; break;
            case 1: cost = rareBaseCost; break;
            case 2: cost = epicBaseCost; break;
            case 3: cost = legendaryBaseCost; break;
        }
        return cost;
    }
}