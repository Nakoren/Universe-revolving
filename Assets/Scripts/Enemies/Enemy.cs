using System;
using Mono.Cecil;
using Unity.Behavior;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AgentMovement m_movement;
    private AgentAttack m_attack;
    private AgentDeath m_death;
    private Health m_health;

    public Action<Enemy> onEnemyDeath;
    public Action<Enemy> onEnemyAttack;
    public Action<Enemy> onEnemyMove;
    public Action<Enemy> onEnemyGetDamage;

    private bool m_dead;
    
    private BehaviorGraphAgent m_graphAgent;
    [SerializeField] private Transform target;

    public void Awake()
    {
        m_movement = GetComponent<AgentMovement>();
        m_attack = GetComponent<AgentAttack>();
        m_death=GetComponent<AgentDeath>();
        m_graphAgent = GetComponent<BehaviorGraphAgent>();
        m_health=GetComponent<Health>();


        m_death.AgentDie+=Die;
        m_movement.AgentMove+=Move;
        m_attack.OnAgentAttack+=Attack;
        m_health.onAgentDamage+=GetDamage;
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
        m_graphAgent.End();
        if (onEnemyDeath!=null)
        {
            onEnemyDeath?.Invoke(this);
        }
    }

    public void Attack(Vector3 vector)
    {
        if (m_attack != null)
        {
            onEnemyAttack?.Invoke(this);
        }
    }

    public void GetDamage()
    {
        if(m_health!=null)
        {
            onEnemyGetDamage?.Invoke(this);
        } 
    }

    public void SetTarget(Transform target)
    {
        m_graphAgent.BlackboardReference.SetVariableValue<Transform>("Player", target);
    }

}
