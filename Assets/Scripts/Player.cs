using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Movement))]

public class Player : MonoBehaviour
{
    enum PlayerState { Frozen, Base, Dash }

    [SerializeField] MeleePunch m_meleePunch;
    Movement m_movement;
    Shoot m_shoot;
    Dash m_dash;
    Health m_health;
    private PlayerState m_state = PlayerState.Base;
    public Action onPlayerDeath;

    private Vector3 m_position = new Vector3();
    private Vector3 m_prevFramePosition = new Vector3();
    

    public void Awake()
    {
        m_movement = GetComponent<Movement>();
        m_shoot = GetComponent<Shoot>();
        m_dash = GetComponent<Dash>();
        m_health = GetComponent<Health>();

        m_dash.onDashStart += setStateToDash;
        m_dash.onDashEnd += setStateToBase;

        m_prevFramePosition = transform.position;
    }

    private void LateUpdate()
    {
        Debug.Log(m_state);
        m_prevFramePosition = m_position;
        m_position = transform.position;
    }

    public void Move(Vector3 direction, Vector3 basicAngle)
    {
        if(m_state == PlayerState.Base) {
            m_movement.Move(direction, basicAngle);
        }
        if(m_state == PlayerState.Dash)
        {
            m_dash.DashMove();
        }
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
        m_meleePunch.Attack();
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
        if (m_state == PlayerState.Base)
        {
            if (m_dash != null)
            {
                Vector3 dashDir = m_position - m_prevFramePosition;
                if(dashDir == Vector3.zero)
                {
                    return;
                }
                dashDir.y = 0;
                m_dash.StartDash(dashDir.normalized);
            }
        }
    }

    public void Die()
    {
        if(onPlayerDeath != null)
        {
            onPlayerDeath.Invoke();
        }
    }

    private void setStateToFrozen()
    {
        m_state = PlayerState.Frozen;
    }
    private void setStateToDash()
    {
        m_state = PlayerState.Dash;
    }
    private void setStateToBase()
    {
        m_state = PlayerState.Base;
    }
}
