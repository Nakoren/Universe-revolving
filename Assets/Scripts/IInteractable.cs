using System;
using UnityEngine;

public abstract class IInteractable: MonoBehaviour
{
    [SerializeField] GameObject displayUI;

    public Action onInteract;
    public Action<IInteractable> onDestroy;
    public bool active;
    
    abstract public void Interact(Player player);

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
