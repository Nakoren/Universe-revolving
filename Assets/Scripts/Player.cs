using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Movement))]

public class Player : MonoBehaviour
{
    Movement m_movement;

    public void Awake()
    {
        m_movement = GetComponent<Movement>();
    }

    public void Move(Vector3 direction, Vector3 basicAngle)
    {
        m_movement.Move(direction, basicAngle);
    }

    public void RotateTo(Vector3 target)
    {
        m_movement.RotateToPosition(target);
    }

    public void Skill1()
    {
        Debug.Log("Used skill 1");
    }

    public void Skill2()
    {
        Debug.Log("Used skill 2");
    }

    public void ExtraAction()
    {
        Debug.Log("Used extra action");
    }

    public void Dash()
    {
        Debug.Log("Used dash");
    }
}
