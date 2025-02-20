using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Movement))]

public class Player : MonoBehaviour
{
    enum PlayerState { Frozen, Base, Dash }

    Movement m_movement;
    Dash m_dash;
    Health m_health;
    MeleePunch m_meleePunch;
    WeaponManager m_weaponManager;
<<<<<<< HEAD
    SkillManager m_skillManager;
    InteractableObjectDetector m_interactableObjectDetector;
=======
   //SkillManager m_skillManager;
    SkillsManager m_skillsManager;
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
    private PlayerState m_state = PlayerState.Base;
    public Action onDash;
    public Action<Vector3> onMove;
    public Action onPlayerDeath;
    public event Action onPlayerFire;
    public event Action onPlayerSkill1;
    public event Action onPlayerSkill2;

    private Vector3 m_position = new Vector3();
    private Vector3 m_prevFramePosition = new Vector3();
    

    public void Awake()
    {
        m_movement = GetComponent<Movement>();
        m_dash = GetComponent<Dash>();
        m_health = GetComponent<Health>();
        m_meleePunch = GetComponent<MeleePunch>();
        m_weaponManager = GetComponent<WeaponManager>();
<<<<<<< HEAD
        m_skillManager = GetComponent<SkillManager>();
        m_interactableObjectDetector = GetComponent<InteractableObjectDetector>();
=======
        m_skillsManager = GetComponent<SkillsManager>();
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc

        m_dash.onDashStart += setStateToDash;
        m_dash.onDashEnd += setStateToBase;
        //m_interactableObjectDetector.m_closestInteractable.onPickup += Pickup;

        m_health.onZeroHealth += Die;

        m_prevFramePosition = transform.position;
    }

    private void LateUpdate()
    {
        //Debug.Log(m_state);
        m_prevFramePosition = m_position;
        m_position = transform.position;
    }

    public void Move(Vector3 direction, Vector3 basicAngle)
    {
        if(m_state == PlayerState.Base) 
        {
            onMove?.Invoke(direction);
            m_movement.Move(direction, basicAngle);
        }
        if(m_state == PlayerState.Dash)
        {
            m_dash.DashMove();
        }
    }
    public void Pickup(IPart part)
    {
        m_weaponManager.Pickup(part);
    }

    public void Warp(Vector3 position)
    {
        m_movement.WarpTo(position);
    }

    public void RotateTo(Vector3 target)
    {
        m_movement.RotateToPosition(target);
    }

    public void StartFire() 
    {
        m_weaponManager.StartFire();
        onPlayerFire?.Invoke();
    }
    public void StopFire()
    {
        m_weaponManager.StopFire();
    }
        
    public void Skill1()
    {
<<<<<<< HEAD
        m_skillManager.SkillQuse();
=======
        m_skillsManager.ActivateHealingSkill();
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
    }

    public void Skill2()
    {
<<<<<<< HEAD
        m_skillManager.SkillEuse();
=======
        //m_skillsManager.SkillEuse();
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
    }

    public void ExtraAction()
    {
        m_weaponManager.Reload();
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
                if (onDash != null)
                {
                    onDash.Invoke();
                }
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
