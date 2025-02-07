using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Rendering;
using UnityEngine;

public class InteractableObjectDetector : MonoBehaviour
{
    private List<IInteractable> m_interactableObjects;

    private IInteractable m_closestInteractable;

    private Coroutine m_cycleCoroutine;

    private void OnDisable()
    {
        m_cycleCoroutine = StartCoroutine(DetectionCycle());
    }

    private void OnEnable()
    {
        StopCoroutine(m_cycleCoroutine);
    }

    private IEnumerator DetectionCycle()
    {
        while (true)
        {
            if(m_interactableObjects.Count > 0)
            {
                IInteractable newClosestInteractable = m_interactableObjects[0];
                float minDistance = Vector3.Distance(transform.position, m_interactableObjects[0].gameObject.transform.position); ;
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
                    m_closestInteractable.SetInteractableState(false);
                    m_closestInteractable = newClosestInteractable;
                    m_closestInteractable.SetInteractableState(true);
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void UseObject()
    {
        m_closestInteractable.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        IInteractable newObject;
        if(other.gameObject.TryGetComponent<IInteractable>(out newObject))
        {
            m_interactableObjects.Add(newObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        IInteractable otherObject;
        if(other.gameObject.TryGetComponent<IInteractable>(out otherObject))
        {
            m_interactableObjects.Remove(otherObject);
            otherObject.SetInteractableState(false);
        }
    }
}
