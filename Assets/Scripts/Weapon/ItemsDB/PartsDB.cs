using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PartsDB", menuName = "Parts/PartsDB")]
public class PartsDB : ScriptableObject
{
    public List<Item> items;

    // private void OnValidate()
    // {
    //     items.ForEach(item =>
    //     {
    //         if (string.IsNullOrEmpty(item.id))
    //         {
    //             item.id = Guid.NewGuid().ToString();
    //         }
    //     });
    // }

    public Item GetRandomItemOfRarity(int rarity)
    {
        List<Item> rarityItemList = new List<Item>();
        foreach (Item item in items)
        {
            if(item.rare == rarity)
            {
                rarityItemList.Add(item);
            }
        }
        int randomIndex = UnityEngine.Random.Range(0, rarityItemList.Count);
        return rarityItemList[randomIndex];
    }
}
