using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    private NavMeshAgent m_meshAgent;

    public void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 targetPosition)
    {
        m_meshAgent.destination = targetPosition;
    }

}