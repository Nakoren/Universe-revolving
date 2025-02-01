using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;



public class AgentMeleeAttack : MonoBehaviour, IAttack
{
    private float lastAttackTime;
    private NavMeshAgent m_meshAgent;

    [Header("Attack Settings")]
    [SerializeField] private float attackCooldown = 2f;
    public event Action AgentMeleeAttacking;

    private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
    }
    public void Attack(Vector3 targetPosition)
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            AgentMeleeAttacking?.Invoke();
            lastAttackTime = Time.time;
        }
    }
}