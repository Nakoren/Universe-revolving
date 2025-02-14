using System;
using System.Collections.Generic;
using Unity.Android.Gradle;
using UnityEngine;

[CreateAssetMenu(fileName = "PartsDB", menuName = "Parts/PartsDB")]
public class PartsDB : ScriptableObject
{
    [System.Serializable]
    public class Item 
    {
        public string id;
        public string name;
        public string description;
        public Sprite icon;
        public IPart part;
    }
    public List<Item> items;

    public Item GetItem(string id)
    {
        return items.Find(x=>x.id == id);
    }

    private void OnValidate()
    {
        items.ForEach(item =>
        {
            if (string.IsNullOrEmpty(item.id))
            {
                item.id = Guid.NewGuid().ToString();
            }
        });
    }
}
