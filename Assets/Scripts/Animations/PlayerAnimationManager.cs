using System;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;
    private Vector3 moveInput;
    public Player player;
    public Weapon weapon;

    private void OnEnable()
    {
        player.onMove+=UpdateMovementAnimation;
        player.onDash+=OnDashAnimation;
        weapon.onReloadStart+=OnReloadAnimation;
    }

    private void OnDisable()
    {
        player.onMove-=UpdateMovementAnimation;
        player.onDash-=OnDashAnimation;
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


    public void UpdateMovementAnimation(Vector3 input)
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
