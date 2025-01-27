using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;
    private Vector2 moveInput;
    [SerializeField] private PlayerController playerController;

    private void OnEnable()
    {
        playerController.PlayerMove += UpdateMovementAnimation;
        playerController.PlayerDash += OnDashAnimation;
    }

    private void OnDisable()
    {
        playerController.PlayerMove -= UpdateMovementAnimation;
        playerController.PlayerDash -= OnDashAnimation;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    public void UpdateMovementAnimation(Vector2 input)
    {
        moveInput = input;
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", moveInput.x);
        animator.SetFloat("moveY", moveInput.y);
    }

    public void OnDashAnimation()
    {
        animator.SetTrigger("Dash");
    }
}
