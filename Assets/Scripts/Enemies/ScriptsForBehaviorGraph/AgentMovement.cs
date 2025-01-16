using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    private NavMeshAgent m_meshAgent;

    public void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 targetPosition)
    {
        if (m_meshAgent == null) return;
        m_meshAgent.destination = targetPosition;
        m_meshAgent.updateRotation = true;
    }

    public bool HasReachedDestination()
    {
        if (m_meshAgent == null || m_meshAgent.pathPending)
        {
            return false;
        }

        return m_meshAgent.remainingDistance <= m_meshAgent.stoppingDistance;
    }
}
