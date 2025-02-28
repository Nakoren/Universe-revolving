using System;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class Health : MonoBehaviour
{
    [Header("Health settings")]
    public float maxHealth = 100;
    public event Action onAgentDamage;
    public event Action onAgentRestoreHealth;

    private float m_currentHealth;
    public Action onZeroHealth;

    public float GetCurrentHealth()
    {
        float test = m_currentHealth;
        return test;
    }
    public void ToDefault(float HP)
    {
        maxHealth = HP;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    private void Awake()
    {
        m_currentHealth = maxHealth;
    }

    public void RestoreFullHealth()
    {
        m_currentHealth = maxHealth;
        if (onAgentRestoreHealth != null)
        {
            onAgentRestoreHealth.Invoke();
        }
    }
    public void RestoreHealth(float restore)
    {
        if(m_currentHealth+restore >= maxHealth)
        {
            RestoreFullHealth();
        }
        else
        {
            m_currentHealth += restore;
        }
        if (onAgentRestoreHealth != null)
        {
            onAgentRestoreHealth.Invoke();
        }
    }
    public void ReduceHealth(float damage)
    {
        m_currentHealth -= damage;
        if (m_currentHealth>0)
        {
            onAgentDamage?.Invoke();
        }
        Debug.Log($"Health reduced by {damage}. Current health: {m_currentHealth}");
        if(m_currentHealth <= 0)
        {
            if(onZeroHealth != null)
            {
                onZeroHealth.Invoke();
            }
        }
    }
}
