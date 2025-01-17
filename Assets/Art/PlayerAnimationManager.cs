using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;
    private Vector2 moveInput;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void UpdateMovementAnimation(Vector2 input)
    {
        moveInput = input;
        animator.SetFloat("moveX", moveInput.x);
        animator.SetFloat("moveY", moveInput.y);
    }

    public void OnDash()
    {
        animator.SetTrigger("Dash");
    }
}
