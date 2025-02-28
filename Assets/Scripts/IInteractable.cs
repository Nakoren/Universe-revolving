using System;
using Unity.AppUI.UI;
using UnityEngine;
using static PartsDB;

public abstract class IInteractable: MonoBehaviour
{
    [SerializeField] GameObject displayUI;

    public Action onInteract;
    public Action<IInteractable> onDestroy;
    public bool active;
    internal Action<IInteractable> onPickup;

    private void Start()
    {
        if (displayUI != null)
        {
            displayUI.SetActive(false);
        }
    }
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

    private void LateUpdate()
    {
        if (displayUI != null && Camera.main != null)
        {
            displayUI.transform.rotation = Camera.main.transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (displayUI != null) displayUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (displayUI != null) displayUI.gameObject.SetActive(false);
        }
    }
}
