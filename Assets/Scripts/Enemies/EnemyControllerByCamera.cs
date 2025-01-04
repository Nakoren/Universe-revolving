using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerByCamera : MonoBehaviour
{
    private GameObject enemy;
    private Collider enemyCollider;
    private NavMeshAgent m_meshAgent;
    private Transform m_target;

    private Health m_health;

    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform player;
    [SerializeField] private Camera cam;
    
    Plane[] planes;

     private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
        m_health = GetComponent<Health>();
        m_meshAgent.speed=speed;
    }
    void Start()
    {
        cam = Camera.main;
        enemyCollider =  GetComponent<Collider>();
    }
    /* private void FixedUpdate()
    {
        if(m_target)
        {
            if(Time.frameCount % 3 == 0)
            {
                m_meshAgent.destination = m_target.position;
            }
        }

        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
        {
            m_target =null;
            Debug.Log("Enemy has been detected");
        }
        else
        {
            m_target = player.transform;
            m_meshAgent.speed = speed;
            Debug.Log("Nothing has been detected");
        }
    }*/

    void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if (GeometryUtility.TestPlanesAABB(planes, enemyCollider.bounds))
        {
            m_meshAgent.destination = player.position;
            Debug.Log("Enemy has been detected");
        }
        else
        {
            m_meshAgent.ResetPath();
            Debug.Log("Nothing has been detected");
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
