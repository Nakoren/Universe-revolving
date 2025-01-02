using UnityEngine;
using UnityEngine.AI;


public abstract class EnemyBase : MonoBehaviour
{

    protected float lastAttackTime;
    protected NavMeshAgent m_meshAgent;


    [Header("Enemy Settings")]
    [SerializeField] protected float health;


    [Header("Move Settings")]
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected float stopDistance = 2f;


    [Header("Attack Settings")]
    [SerializeField] protected float damage;
    [SerializeField]protected float attackCooldown = 2f;



    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject);
    }

    public abstract void MoveTo(Vector3 targetPosition);
    public abstract void Attack(Vector3 targetPosition);

}

