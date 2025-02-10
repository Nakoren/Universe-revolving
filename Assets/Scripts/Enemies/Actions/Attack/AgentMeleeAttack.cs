using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class AgentMeleeAttack : MonoBehaviour, IAttack
{
    private float lastAttackTime;
    private NavMeshAgent m_meshAgent;


    public event Action AgentAttack; //убрать из интерфейса

    private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
    }
    public void Attack(Vector3 targetPosition)
    {
       
            lastAttackTime = Time.time;
        
    }
}