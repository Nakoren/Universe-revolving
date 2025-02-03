using System;
using Mono.Cecil;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private AgentMovement m_movement;
    private AgentRotation m_rotation;
    private IAttack m_attack;
    private AgentDeath m_death;

    public Action onEnemyDeath;
        

    

    public void Awake()
    {
        m_movement = GetComponent<AgentMovement>();
        m_attack = GetComponent<IAttack>();
        m_rotation=GetComponent<AgentRotation>();
        m_death=GetComponent<AgentDeath>();

        m_death.AgentDie+=Die;

    }

    private void Die()
    {
        if(onEnemyDeath!=null)
        {
            onEnemyDeath?.Invoke();
        }
    }


    public void Attack(Vector3 target)
    {
        if (m_attack == null)
        {
            Debug.LogWarning("IAttack component not found on Agent.");
        }
        m_attack.Attack(target);
    }

    public void Rotate(Vector3 target)
    {
        if (m_rotation == null)
        {
            Debug.LogWarning("AgentRotation component not found on Agent.");
        }
        m_rotation.RotateTowardsTarget(target);
    }

    



}
