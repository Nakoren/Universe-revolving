using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Movement))]

public class Player : MonoBehaviour
{
    Movement m_movement;
    Shoot m_shoot;
    [SerializeField] private MeleePunch m_meleePunch;

    public void Awake()
    {
        m_movement = GetComponent<Movement>();
        m_shoot = GetComponent<Shoot>();
    }

    public void Move(Vector3 direction, Vector3 basicAngle)
    {
        m_movement.Move(direction, basicAngle);
    }

    public void RotateTo(Vector3 target)
    {
        m_movement.RotateToPosition(target);
    }

    public void Shoot() 
    {
        if(m_shoot != null)
        {
            m_shoot.ShootAction();
        }
    }
        
    public void Skill1()
    {
        if(m_meleePunch != null)
        {
        m_meleePunch.Attack();
        }
    }

    public void Skill2()
    {
        Debug.Log("Used skill 2");
    }

    public void ExtraAction()
    {
        m_shoot.Reload();
    }

    public void Dash()
    {
        
    }
}
