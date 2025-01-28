using UnityEngine;
using UnityEngine.AI;
using System;

public class AgentRangedAttack : MonoBehaviour, IAttack
{
    protected float lastAttackTime;
    protected NavMeshAgent m_meshAgent;

    [Header("Attack Settings")]
    [SerializeField] private float attackCooldown = 2f;


    [Header("Projectile Settings")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnBullet;

    [Header("Shoot Settings")]
    [SerializeField] private float shootForce = 1f;
    [SerializeField] private float shootAngle;
     public event Action AgentRangedAttacking;

     public  void Attack(Vector3 targetPosition)
    {
        targetPosition.y = spawnBullet.position.y;

        Vector3 directionToTarget = (targetPosition - spawnBullet.position).normalized;

        float angle = Vector3.Angle(transform.forward, directionToTarget);

        if (angle <= shootAngle)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                GameObject currentBullet = Instantiate(projectilePrefab, spawnBullet.position, Quaternion.identity);
                AgentRangedAttacking?.Invoke();

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
           //Debug.Log($"Цель вне допустимого угла: {angle}° (максимально допустимый: {shootAngle}°)");
        }
    }
}
