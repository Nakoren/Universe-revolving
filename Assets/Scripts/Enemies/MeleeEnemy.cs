using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemy : EnemyBase
{
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
    if (m_meshAgent.remainingDistance <= m_meshAgent.stoppingDistance)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            Debug.Log("Enemy Attack");
            lastAttackTime = Time.time;
        }
    }
}

}
