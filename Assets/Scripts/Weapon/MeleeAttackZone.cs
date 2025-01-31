using UnityEngine;

public class MeleeAttackZone : MonoBehaviour
{
    [SerializeField] private AgentMeleeAttack agentMeleeAttack;
    [SerializeField] private int damage = 10;

    private Health playerHealth;


    private void OnEnable()
    {
        if (agentMeleeAttack != null)
        {
            agentMeleeAttack.AgentMeleeAttacking += OnAttack;
        }
    }

    private void OnDisable()
    {
        if (agentMeleeAttack != null)
        {
            agentMeleeAttack.AgentMeleeAttacking -= OnAttack;
        }
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

    private void OnAttack()
    {
        playerHealth.ReduceHealth(damage); 
        Debug.Log($"Player took {damage} damage. Current health: {playerHealth.GetCurrentHealth()}");
    }

}
