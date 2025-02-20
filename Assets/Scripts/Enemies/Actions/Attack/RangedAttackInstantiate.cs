using UnityEngine;

public class RangedAttackInstantiate : MonoBehaviour
{
    [SerializeField] private AgentAttack agentAttack;

    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnBullet;

    [Header("Shoot Settings")]
    [SerializeField] private float shootForce = 1f;
    [SerializeField] private float shootAngle;


    private void OnEnable()
    {
        agentAttack.OnAgentAttack += OnAttack;
    }

    private void OnDisable()
    {
        agentAttack.OnAgentAttack += OnAttack;
    }


    private void OnAttack(Vector3 target)
    {
        target.y = spawnBullet.position.y;
        Vector3 directionToTarget = (target - spawnBullet.position).normalized;

        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (angle <= shootAngle)
        {
            float maxRange = 100f;

            RaycastHit hit;
            if (Physics.Raycast(spawnBullet.position, directionToTarget, out hit, maxRange))
            {
                if (hit.transform.CompareTag("Player") || hit.transform.GetComponent<Health>() != null)
                {
                    GameObject currentBullet = Instantiate(projectilePrefab, spawnBullet.position, Quaternion.identity);
                    currentBullet.transform.forward = directionToTarget;

                    Rigidbody bulletRb = currentBullet.GetComponent<Rigidbody>();
                    if (bulletRb != null)
                    {
                        bulletRb.AddForce(directionToTarget * shootForce, ForceMode.Impulse);
                    }
                }
                else
                {
                    Debug.Log("Raycast did not hit the target.");
                }
            }

        }
    }
}
