using UnityEngine;

public class MeleeAttackZone : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private int damage = 10;

    private Health playerHealth;


    private void OnEnable()
    {
        enemy.onEnemyAttack += OnAttack;
    }

    private void OnDisable()
    {
        enemy.onEnemyAttack -= OnAttack;
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

    private void OnAttack(Enemy enemy)
    {
        if (playerHealth)
        {
            playerHealth.ReduceHealth(damage);
            Debug.Log($"Player took {damage} damage. Current health: {playerHealth.GetCurrentHealth()}");
        }

    }

}
