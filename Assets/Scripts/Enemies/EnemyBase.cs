using UnityEngine;
using UnityEngine.AI;


public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float health;
    [SerializeField] protected float damage;

    protected float lastAttackTime;
    protected NavMeshAgent m_meshAgent;


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
