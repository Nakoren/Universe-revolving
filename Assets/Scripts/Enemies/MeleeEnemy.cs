using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : EnemyBase
{
    private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
        m_meshAgent.speed = moveSpeed;
        m_meshAgent.stoppingDistance = stopDistance;
    }

    public override void MoveTo(Vector3 targetPosition)
    {
        if (Vector3.Distance(transform.position, targetPosition) > stopDistance)
        {
            m_meshAgent.destination = targetPosition;
        }
        else
        {
            m_meshAgent.ResetPath();
        }
    }

    public override void Attack(Vector3 targetPosition)
    {
        if (Vector3.Distance(transform.position, targetPosition) <= stopDistance)
        {
            if (Time.time - lastAttackTime >= attackCooldown)
                {
                    Debug.Log("Enemy Attack");
                    lastAttackTime = Time.time; 
                }

        }
    }
}
