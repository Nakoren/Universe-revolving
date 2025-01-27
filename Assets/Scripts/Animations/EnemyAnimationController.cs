//using System.Numerics;
using System;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator; 
    [SerializeField] private AgentMovement agentMovement; 
    [SerializeField] private AgentMeleeAttack agentMeleeAttack; 
    [SerializeField] private AgentDeath agentDeath; 


    private void OnEnable()
    {
        agentMovement.AgentMove += UpdateMovementAnimation;
        agentMovement.AgentStop += StopMoveAnimation;
        if(agentMeleeAttack)
        {
            agentMeleeAttack.AgentMeleeAttacking+=OnMeeleAttackAnimation;
        }
        agentDeath.AgentDie += StartDieAnimation;

    }

    private void OnDisable()
    {
        agentMovement.AgentMove -= UpdateMovementAnimation;
        agentMovement.AgentStop -= StopMoveAnimation;
        if(agentMeleeAttack)
        {
            agentMeleeAttack.AgentMeleeAttacking-=OnMeeleAttackAnimation;
        }
        agentDeath.AgentDie -= StartDieAnimation;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void UpdateMovementAnimation(Vector3 input)
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", input.x);
        animator.SetFloat("moveY", input.z);
    }
    private void StopMoveAnimation()
    {
        animator.SetBool("isMoving", false);
    }

    public void OnMeeleAttackAnimation()
    {
        animator.SetTrigger("Attack");
    }

    private void StartDieAnimation()
    {
         animator.SetTrigger("Die");
    }

}
