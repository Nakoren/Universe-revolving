using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;

public class InteractableObjectDetector : MonoBehaviour
{
    private List<IInteractable> interactableObjects;

    public void UseObject()
    {
        interactableObjects.Last().Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable newObject;
        if(other.gameObject.TryGetComponent<IInteractable>(out newObject))
        {
            interactableObjects.Last().SetInteractableState(false);
            interactableObjects.Add(newObject);
            newObject.SetInteractableState(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IInteractable otherObject;
        if(other.gameObject.TryGetComponent<IInteractable>(out otherObject))
        {
            interactableObjects.Remove(otherObject);    
            otherObject.SetInteractableState(false);
        }
    }
}
