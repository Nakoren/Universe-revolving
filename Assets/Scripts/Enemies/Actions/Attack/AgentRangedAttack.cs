using UnityEngine;
using UnityEngine.AI;
using System;
using Unity.VisualScripting;

public class AgentRangedAttack : MonoBehaviour, IAttack
{
    protected float lastAttackTime;
    protected NavMeshAgent m_meshAgent;


    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnBullet;

    [Header("Shoot Settings")]
    [SerializeField] private float shootForce = 1f;
    [SerializeField] private float shootAngle;

    public event Action AgentAttack; // надо убрать из интерфейса

    public void Attack(Vector3 targetPosition)
    {
        targetPosition.y = spawnBullet.position.y;

        Vector3 directionToTarget = (targetPosition - spawnBullet.position).normalized;

        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (angle <= shootAngle)
        {

            GameObject currentBullet = Instantiate(projectilePrefab, spawnBullet.position, Quaternion.identity);
            currentBullet.transform.forward = directionToTarget;

            Rigidbody bulletRb = currentBullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                bulletRb.AddForce(directionToTarget * shootForce, ForceMode.Impulse);
            }
            AgentAttack?.Invoke();
            lastAttackTime = Time.time;
        }
        else
        {
        }
    }
}
