using System;
using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class Health : MonoBehaviour
{
    [Header("Health settings")]
    [SerializeField] public float maxHealth = 100;
    public event Action AgentDamage;

    private float m_currentHealth;
    public Action onZeroHealth;

    public float GetCurrentHealth()
    {
        return m_currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    private void Start()
    {
        m_currentHealth = maxHealth;
    }

    public void RestoreFullHealth()
    {
        m_currentHealth = maxHealth;
    }
    public void RestoreHealth(float restore)
    {
        m_currentHealth += restore;
    }
    public void ReduceHealth(float damage)
    {
        m_currentHealth -= damage;
        if (m_currentHealth>0)
        {
            AgentDamage?.Invoke();
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
