using System;
using UnityEngine;

public class Transitor : IInteractable
{
    public int targetInd;
    public Room roomSO;
    public Action<int> onActivate;
    private DoorsAnimationController doorController;
    private bool isActive = false;
    private void Awake()
    {
        doorController = GetComponent<DoorsAnimationController>();   
    }
    public void Initiate(Room room, int roomInd)
    {
        roomSO = room;
        targetInd = roomInd;
    }
    public void Enable()
    {
        this.isActive = true;
        doorController.OpenDoorsAnimation();
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
