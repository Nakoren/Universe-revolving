using System;
using UnityEngine;

public interface IInteractable
{
    public Action OnInteract();
    public void Interact();
    public bool active();

    public void SetInteractableState(bool newState);
}
