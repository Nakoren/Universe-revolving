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
}
