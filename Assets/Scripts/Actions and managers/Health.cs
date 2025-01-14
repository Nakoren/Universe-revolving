using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health settings")]
    [SerializeField] public int maxHealth = 100;

    private int m_currentHealth;
    public Action onZeroHealth;

    public int GetCurrentHealth()
    {
        return m_currentHealth;
    }

    public int GetMaxHealth()
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
    public void RestoreHealth(int restore)
    {
        m_currentHealth += restore;
    }
    public void ReduceHealth(int damage)
    {
        m_currentHealth -= damage;
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
