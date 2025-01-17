using System;
using UnityEngine;

public class Transitor : MonoBehaviour
{
    public int targetInd;
    public Room roomSO;
    public Action<int> onActivate;
    public void Initiate(Room room, int roomInd)
    {
        roomSO = room;
        targetInd = roomInd;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log($"Active transition to room {roomSO.name}");
            Activate();
        }
    }

    private void Activate()
    {
        onActivate.Invoke(targetInd);
    }
}
