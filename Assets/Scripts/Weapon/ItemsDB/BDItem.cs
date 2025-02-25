using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Parts/Item")]
public class Item : ScriptableObject
{
        public int id;
        public int rare;
        public string itemName;
        public string description;
        public Sprite icon;
        public IPart part;
}
