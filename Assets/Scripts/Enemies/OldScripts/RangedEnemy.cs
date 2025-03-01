using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : EnemyBase
{

    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnBullet;

    [Header("Shoot Settings")]
    [SerializeField] private float shootForce = 1f;
    [SerializeField] private float shootAngle;


    private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
    }

    public override void MoveTo(Vector3 targetPosition)
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


    public override void Attack(Vector3 targetPosition)
    {
        targetPosition.y = spawnBullet.position.y;

        Vector3 directionToTarget = (targetPosition - spawnBullet.position).normalized;

        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (angle <= shootAngle)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                GameObject currentBullet = Instantiate(projectilePrefab, spawnBullet.position, Quaternion.identity);

                currentBullet.transform.forward = directionToTarget;

                Rigidbody bulletRb = currentBullet.GetComponent<Rigidbody>();
                if (bulletRb != null)
                {
                    bulletRb.AddForce(directionToTarget * shootForce, ForceMode.Impulse);
                }
                else
                {
                    Debug.LogError("Projectile prefab is missing a Rigidbody component!");
                }

                //Debug.Log($"Враг стреляет в направлении {targetPosition}");
                lastAttackTime = Time.time;
            }

        }
        else
        {
           // Debug.Log($"Цель вне допустимого угла: {angle}° (максимально допустимый: {shootAngle}°)");
        }
    }
}
