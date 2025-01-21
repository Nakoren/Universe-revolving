//using System.Numerics;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator; 
    [SerializeField] private AgentMovement agentMovement; 
    [SerializeField] private AgentMeleeAttack agentMeleeAttack; 


    private void OnEnable()
    {
        agentMovement.AgentMove += UpdateMovementAnimation;
        agentMovement.AgentStop += StopMoveAnimation;
        if(agentMeleeAttack)
        {
            agentMeleeAttack.AgentMeleeAttacking+=OnMeeleAttackAnimation;
        }
    }

    private void OnDisable()
    {
        agentMovement.AgentMove -= UpdateMovementAnimation;
        agentMovement.AgentStop -= StopMoveAnimation;
        if(agentMeleeAttack)
        {
            agentMeleeAttack.AgentMeleeAttacking-=OnMeeleAttackAnimation;
        }
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
}
