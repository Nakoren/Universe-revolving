using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof (CharacterController))]

public class Player : MonoBehaviour
{
    public int speed;
    public InputActionAsset inputActions;
    private InputAction m_moveAction;
    private CharacterController m_charController;

    private void Awake()
    {
        m_moveAction = inputActions.FindAction("Player/Move");
        m_charController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        m_moveAction.Enable();
    }

    void Update()
    {
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        if (move.magnitude > 0)
        {
            Move(move, new Vector2(1,1));
        }
        else
        {
            m_charController.SimpleMove(new Vector3());
        }
    }

    public void Move(Vector2 moveDir, Vector2 rotation)
    {
        float baseMovementAngle = Mathf.Atan2(moveDir.y, moveDir.x);
        float newAngle = baseMovementAngle + Mathf.Atan2(rotation.y, rotation.x);
        //Debug.Log(baseMovementAngle + " " + newAngle);
        float x = Mathf.Cos(newAngle);
        float y = Mathf.Sin(newAngle);

        Vector3 moveDirV3 = new Vector3(x, 0f, y);
        //Debug.Log(moveDirV3);
        m_charController.SimpleMove(moveDirV3 * speed);
    }
}
