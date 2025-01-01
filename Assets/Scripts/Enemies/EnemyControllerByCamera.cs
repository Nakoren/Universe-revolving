using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerByCamera : MonoBehaviour
{
    private Collider enemyCollider;
    private EnemyBase enemyObject;

    [SerializeField] private Transform player;
    [SerializeField] private Camera cam;

    private Plane[] planes;


    private void Start()
    {
        cam = Camera.main;
        enemyCollider = GetComponent<Collider>();
        enemyObject = GetComponent<EnemyBase>();
    }

    private void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);

        if (GeometryUtility.TestPlanesAABB(planes, enemyCollider.bounds))
        {
            enemyObject.MoveTo(player.position);
            enemyObject.Attack(player.position);
        }
    }
   
}
