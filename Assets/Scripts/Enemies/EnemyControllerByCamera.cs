using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerByCamera : MonoBehaviour
{
    private NavMeshAgent m_meshAgent;
    private Collider enemyCollider;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float stopDistance = 2f; 
    [SerializeField] private Transform player;
    [SerializeField] private Camera cam;

    private Plane[] planes;

    private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
        m_meshAgent.speed = speed;
        m_meshAgent.stoppingDistance = stopDistance; 
    }

    private void Start()
    {
        cam = Camera.main;
        enemyCollider = GetComponent<Collider>();
    }

    private void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);

        if (GeometryUtility.TestPlanesAABB(planes, enemyCollider.bounds))
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer > stopDistance)
            {
                m_meshAgent.destination = player.position;
            }
            else
            {
                m_meshAgent.ResetPath();
            }
        }
        else
        {
            m_meshAgent.ResetPath();
        }
    }
}
