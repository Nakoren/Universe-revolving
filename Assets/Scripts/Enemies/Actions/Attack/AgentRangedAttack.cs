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
            else
            {
                Debug.LogError("Projectile prefab is missing a Rigidbody component!");
            }
            //Debug.Log($"Враг стреляет в направлении {targetPosition}");
            lastAttackTime = Time.time;

        }
        else
        {
            //Debug.Log($"Цель вне допустимого угла: {angle}° (максимально допустимый: {shootAngle}°)");
        }
    }
}
