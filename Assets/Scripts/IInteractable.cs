using System;
using UnityEngine;

public abstract class IInteractable: MonoBehaviour
{
    public Action OnInteract;
    public bool active;
    abstract public void Interact();
    
    abstract public void SetInteractableState(bool newState);
}
