using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Health settings")]
    [SerializeField] public int maxHealth = 10;

    private int m_currentHealth;
    public Action onZeroHealth;

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
        if(m_currentHealth <= 0)
        {
            if(onZeroHealth != null)
            {
                onZeroHealth.Invoke();
            }
        }
    }
}