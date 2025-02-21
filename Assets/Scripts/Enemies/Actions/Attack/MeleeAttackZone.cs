using UnityEngine;

public class MeleeAttackZone : MonoBehaviour
{
    [SerializeField] private AgentAttack agentAttack;
    
    [SerializeField] private int damage = 10;

    private Health playerHealth;


    private void OnEnable()
    {
        agentAttack.OnAgentAttack+=OnAttack;
    }

    private void OnDisable()
    {
        agentAttack.OnAgentAttack+=OnAttack;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = other.GetComponent<Health>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth = null;
        }
    }

    private void OnAttack(Vector3 target)
    {
        if (playerHealth)
        {
            playerHealth.ReduceHealth(damage);
            Debug.Log($"Player took {damage} damage. Current health: {playerHealth.GetCurrentHealth()}");
        }

    }

}
