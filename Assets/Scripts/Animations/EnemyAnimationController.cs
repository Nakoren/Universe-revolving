//using System.Numerics;
using System;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private Health health;
    [SerializeField] private AgentMovement agentMovement;

    [SerializeField] private Enemy enemy;
    [SerializeField] private AgentDeath agentDeath;


    private void OnEnable()
    {
        agentMovement.AgentMove += UpdateMovementAnimation;
        agentMovement.AgentStop += StopMoveAnimation;
        enemy.onEnemyAttack += OnAttackAnimation;
        agentDeath.AgentDie += StartDieAnimation;
        if (health)
        {
            health.onAgentDamage += OnDamageAnimation;
        }
    }


    private void OnDisable()
    {
        agentMovement.AgentMove -= UpdateMovementAnimation;
        agentMovement.AgentStop -= StopMoveAnimation;

        enemy.onEnemyAttack -= OnAttackAnimation;
        agentDeath.AgentDie -= StartDieAnimation;
        if (health)
        {
            health.onAgentDamage -= OnDamageAnimation;
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void UpdateMovementAnimation(Vector3 moveInput)
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", moveInput.x);
        animator.SetFloat("moveY", moveInput.y);
    }
    private void StopMoveAnimation()
    {
        animator.SetBool("isMoving", false);
    }

    private void OnDamageAnimation()
    {
        animator.SetTrigger("Hit");
    }

    public void OnAttackAnimation(Enemy enemy)
    {
        animator.SetTrigger("Attack");
    }

    private void StartDieAnimation()
    {
        animator.SetTrigger("Die");
    }

}
