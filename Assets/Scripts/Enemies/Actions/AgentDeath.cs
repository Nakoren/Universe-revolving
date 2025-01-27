using System;
using UnityEngine;

public class AgentDeath : MonoBehaviour
{
    public event Action AgentDie;
    [SerializeField] private float destroyDelay = 2f;

    public void Die()
    {
        AgentDie?.Invoke();
        Debug.Log($"[AgentDeath]: Враг умер. Объект будет уничтожен через {destroyDelay} секунд.");
        Destroy(gameObject, destroyDelay);
    }
}
