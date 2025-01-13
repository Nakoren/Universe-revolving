using UnityEngine;

[CreateAssetMenu(fileName = "Room", menuName = "Room")]
public class Room: ScriptableObject
{
    public GameObject room;
    public string roomName;
    public int weight;

    public override string ToString()
    {
        return this.name;
    }
}
