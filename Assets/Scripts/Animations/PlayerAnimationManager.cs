using System;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;
    private Vector2 moveInput;
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Weapon weapon;

    private void OnEnable()
    {
        playerController.onPlayerMove += UpdateMovementAnimation;
        playerController.onPlayerDash += OnDashAnimation;
        //playerController.PlayerReload+=OnReloadAnimation;
        weapon.onReloadStart+=OnReloadAnimation;
    }

    private void OnDisable()
    {
        playerController.onPlayerMove -= UpdateMovementAnimation;
        playerController.onPlayerDash -= OnDashAnimation;
        //playerController.PlayerReload-=OnReloadAnimation;
        weapon.onReloadStart-=OnReloadAnimation;
    }

    private void OnReloadAnimation()
    {
       animator.SetTrigger("Reload");
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
