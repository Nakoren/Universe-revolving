using System;
using Mono.Cecil;
using Unity.Behavior;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AgentMovement m_movement;
    private IAttack m_attack;
    private AgentDeath m_death;

    public Action<Enemy> onEnemyDeath;
    public Action<Enemy> onEnemyAttack;
    public Action<Enemy> onEnemyMove;
    
    private BehaviorGraphAgent m_graphAgent;

    public void Awake()
    {
        m_movement = GetComponent<AgentMovement>();
        m_attack = GetComponent<IAttack>();
        m_death=GetComponent<AgentDeath>();
        m_graphAgent = GetComponent<BehaviorGraphAgent>();

        m_death.AgentDie+=Die;
        m_movement.AgentMove+=Move;
        m_attack.AgentAttack+=Attack;
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
    }

    public void Move(Vector3 vector)
    {
        if(onEnemyMove!=null)
        {
            onEnemyMove?.Invoke(this);
        } 
    }

    public void Die()
    {
        if(onEnemyDeath!=null)
        {
            onEnemyDeath?.Invoke(this);
        }
    }

    public void Attack()
    {
        if (m_attack! == null)
        {
            onEnemyAttack?.Invoke(this);
        }
    }

    public void SetTarget(Transform target)
    {
        m_graphAgent.BlackboardReference.SetVariableValue<Transform>("Player", target);
    }

}
