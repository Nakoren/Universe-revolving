using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;



public class AgentMeleeAttack : MonoBehaviour, IAttack
{
    private float lastAttackTime;
    private NavMeshAgent m_meshAgent;

    [Header("Attack Settings")]
    [SerializeField] private GameObject hitBox;
    [SerializeField] private float attackCooldown = 2f;
    public event Action AgentMeleeAttacking;

    private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
        hitBox.SetActive(false);
    }
    public void Attack(Vector3 targetPosition)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            hitBox.SetActive(true);
            AgentMeleeAttacking?.Invoke();
            StartCoroutine(DisableHitBoxAfterDelay(0.1f));
            lastAttackTime = Time.time;
            
        }
    }
    private IEnumerator DisableHitBoxAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hitBox.SetActive(false);
    }
}