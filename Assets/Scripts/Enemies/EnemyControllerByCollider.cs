using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerByCollider : MonoBehaviour
{
    private NavMeshAgent m_meshAgent;
    [SerializeField] private Transform m_target;
    [SerializeField] private float speed = 2f;

    private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
        m_meshAgent.speed = speed;
    }

    private void Update()
    {
        if (m_target)
        {
            if (Time.frameCount % 3 == 0)
            {
                m_meshAgent.destination = m_target.position;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            m_target = null;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Player>(out var player))
        {
            m_target = player.transform;
            m_meshAgent.speed = speed;
        }
    }
}
