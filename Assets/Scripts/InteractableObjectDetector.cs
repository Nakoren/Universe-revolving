using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectDetector : MonoBehaviour
{
    private List<IInteractable> m_interactableObjects = new List<IInteractable>();
    private IInteractable m_closestInteractable;
    private Coroutine m_cycleCoroutine;
    private Player m_player;

    private void Awake()
    {
        m_player = GetComponent<Player>();
        m_cycleCoroutine = StartCoroutine(DetectionCycle());
    }

    private void OnDisable()
    {
        if (m_cycleCoroutine != null)
        {
            StopCoroutine(m_cycleCoroutine);
        }
    }

    private IEnumerator DetectionCycle()
    {
        while (true)
        {
            if(m_interactableObjects.Count > 0)
            {
                IInteractable newClosestInteractable = m_interactableObjects[0];
                float minDistance = Vector3.Distance(transform.position, m_interactableObjects[0].gameObject.transform.position);
                for (int i = 1; i < m_interactableObjects.Count; i++)
                {
                    float curDistance = Vector3.Distance(transform.position, m_interactableObjects[i].gameObject.transform.position);
                    if (curDistance < minDistance)
                    {
                        newClosestInteractable = m_interactableObjects[i];
                        minDistance = curDistance;
                    }
                }
                if (m_closestInteractable != newClosestInteractable)
                {
                    if (m_closestInteractable != null)
                    {
                        m_closestInteractable.SetInteractableState(false);
                    }
                    m_closestInteractable = newClosestInteractable;
                    m_closestInteractable.SetInteractableState(true);
                }
                if (m_closestInteractable != null)
                {
                    //Debug.Log($"Closest object: {m_closestInteractable.name}");
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    private void onInteractableDestroy()
    {

    }

    public void UseObject()
    {
        if (m_closestInteractable != null)
        {
            m_closestInteractable.onPickup += Pickup;
            m_closestInteractable.Interact();
            m_closestInteractable.onPickup -= Pickup;
        }
        else
        {
            //Debug.Log("No item to interact");
        }
    }

    private void Pickup(IInteractable obj)
    {
        m_player.Pickup(obj);
    }

    private void OnInteractableDestroy(IInteractable interactable)
    {
        if(m_closestInteractable == interactable)
        {
            m_closestInteractable = null;
        }
        m_interactableObjects.Remove(interactable);
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable newObject;
        if(other.gameObject.TryGetComponent<IInteractable>(out newObject))
        {
            m_interactableObjects.Add(newObject);
            newObject.onDestroy += OnInteractableDestroy;
           // Debug.Log($"Added to interactable: {newObject.name}");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IInteractable otherObject;
        if(other.gameObject.TryGetComponent<IInteractable>(out otherObject))
        {
            m_interactableObjects.Remove(otherObject);
            otherObject.SetInteractableState(false);
            otherObject.onDestroy -= OnInteractableDestroy;
            //Debug.Log($"Removed to interactable: {otherObject.name}");
        }
    }
}
