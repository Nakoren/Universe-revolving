using System;
using UnityEngine;

public class Transitor : IInteractable
{
    public int targetInd;
    public Room roomSO;
    public Action<int> onActivate;
    public void Initiate(Room room, int roomInd)
    {
        roomSO = room;
        targetInd = roomInd;
    }

    override public void Interact()
    {
        Activate();
    }

    private void Activate()
    {
        onActivate.Invoke(targetInd);
    }
}
