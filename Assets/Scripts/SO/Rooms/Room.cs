using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Room", menuName = "RoomTypes/Room")]
public class Room: ScriptableObject
{
    public GameObject prefab;
    public string roomName;
    public int weight;

    public override string ToString()
    {
        return this.name;
    }
}
