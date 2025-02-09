using UnityEngine;
using UnityEngine.AI;


public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent m_meshAgent;

    [Header("Move Settings")]
    [SerializeField] protected float rotationSpeed = 5f;

    public void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
    }

    public  void Move(Vector3 targetPosition)
    {
        m_meshAgent.destination = targetPosition;
        m_meshAgent.updateRotation = true;

        Vector3 directionToTarget = (targetPosition - transform.position).normalized;

        if (m_meshAgent.remainingDistance <= m_meshAgent.stoppingDistance && directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }


}
