using System;
using UnityEngine;
using static PartsDB;

public abstract class IInteractable: MonoBehaviour
{
    [SerializeField] GameObject displayUI;

    public Action onInteract;
    public Action<IInteractable> onDestroy;
    public bool active;
    internal Action<Item> onPickup;

    abstract public void Interact();

    private void OnDestroy()
    {
        if (onDestroy != null)
        {
            onDestroy.Invoke(this);
        }
    }

    public void SetInteractableState(bool newState) {
        if (displayUI != null)
        {
            displayUI.SetActive(newState);
        }
        active = newState;
    }
}
