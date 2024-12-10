using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Player : MonoBehaviour
{
    public int speed;
    
    private CharacterController m_charController;


    private void Awake()
    {
        m_charController = GetComponent<CharacterController>();
    }


    public void Move(Vector2 moveDir, Vector3 baseDirection)
    {
        if(!(moveDir.magnitude > 0))
        {
            m_charController.SimpleMove(new Vector3());
            return;
        }
        Debug.Log(baseDirection);
        
        

        float baseMovementAngle = Mathf.Atan2(moveDir.y, moveDir.x);
        float newAngle = baseMovementAngle - Mathf.Atan2(baseDirection.x, baseDirection.z);
        //Debug.Log(baseMovementAngle + " " + newAngle);
        float x = Mathf.Cos(newAngle);
        float y = Mathf.Sin(newAngle);
        
        Vector3 moveDirV3 = new Vector3(x, 0f, y);

        //Debug.Log(moveDirV3);

        
        m_charController.SimpleMove(moveDirV3 * speed);
    }

    public void RotateToPosition(Vector3 position)
    {
        transform.LookAt(position);
        Quaternion newRotation = new Quaternion(0f, transform.rotation.y, 0f, transform.rotation.w);
        transform.rotation = newRotation;
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
