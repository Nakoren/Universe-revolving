using System;
using UnityEngine;
using UnityEngine.AI;

public class AgentDeath : MonoBehaviour
{
    public event Action AgentDie;
    private NavMeshAgent agent;
    [SerializeField] private float destroyDelay = 3f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void Die()
    {
        AgentDie?.Invoke();
        agent.enabled = false;
        Debug.Log($"[AgentDeath]: Враг умер. Объект будет уничтожен через {destroyDelay} секунд.");
        Destroy(gameObject, destroyDelay);
    }
}
