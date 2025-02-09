using System;
using UnityEngine;

public abstract class IInteractable: MonoBehaviour
{
    [SerializeField] GameObject displayUI;

    public Action OnInteract;
    public bool active;
    
    abstract public void Interact();

    public void SetInteractableState(bool newState) {
        if (displayUI != null)
        {
            displayUI.SetActive(newState);
        }
        active = newState;
    }
}
