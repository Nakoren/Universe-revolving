using UnityEngine;
using UnityEngine.AI;

public class MeleeAttack : MonoBehaviour, IAttack
{
    private float lastAttackTime;
    private NavMeshAgent m_meshAgent;

    [Header("Attack Settings")]
    [SerializeField] protected float damage;
    [SerializeField]protected float attackCooldown = 2f;

    private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
    }
    public void Attack(Vector3 targetPosition)
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
