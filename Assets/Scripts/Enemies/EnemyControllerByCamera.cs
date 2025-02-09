using UnityEngine;
using UnityEngine.AI;

public class EnemyControllerByCamera : MonoBehaviour
{
    private Collider enemyCollider;
    private Enemy enemyObject;

    [SerializeField] private Transform player;
    [SerializeField] private Camera cam;

    private Plane[] planes;


    private void Start()
    {
        cam = Camera.main;
        enemyCollider = GetComponent<Collider>();
        enemyObject = GetComponent<Enemy>();
    }

    private void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(cam);

        if (GeometryUtility.TestPlanesAABB(planes, enemyCollider.bounds))
        {
            //enemyObject.Move(player.position);
           // enemyObject.Attack(player.position);
            //enemyObject.Dash(player.position);
        }
    }
   
}
