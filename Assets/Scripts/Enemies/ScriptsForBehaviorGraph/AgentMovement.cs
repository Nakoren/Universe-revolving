using UnityEngine;
using UnityEngine.AI;
using System;

public class AgentMovement : MonoBehaviour
{
    private NavMeshAgent m_meshAgent;
    public event Action<Vector3> AgentMove;
    public event Action AgentStop;

    public void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 targetPosition)
    {
        m_meshAgent.destination = targetPosition;
        Vector3 direction = (targetPosition - transform.position).normalized;

        if (m_meshAgent.remainingDistance > m_meshAgent.stoppingDistance + 0.1f && !m_meshAgent.pathPending)
        {
            AgentMove?.Invoke(direction);
        }
        else
        {
            AgentStop?.Invoke();
        }
    }

}