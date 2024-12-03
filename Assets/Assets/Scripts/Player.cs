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
        Move(move);
    }

    public void Move(Vector2 moveDir)
    {
        Vector3 moveDirV3 = new Vector3(moveDir.x, 0f, moveDir.y);
        m_charController.SimpleMove(moveDirV3 * speed);
    }
}
