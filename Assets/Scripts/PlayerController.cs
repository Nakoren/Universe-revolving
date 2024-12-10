using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Player player;
    public InputActionAsset inputActions;
    public TerrainCollider terrainCollider;
    public Transform cameraTransform;

    private InputAction m_moveAction;

    private void Awake()
    {
        m_moveAction = inputActions.FindAction("Player/Move");
    }

    void Start()
    {
        m_moveAction.Enable();
    }

    void Update()
    {
        RotateToCursor();
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        player.Move(move, new Vector2(1, 1));
    }

    public void RotateToCursor()
    {
        Vector3 position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;

        if (terrainCollider.Raycast(ray, out rayHit, 1000))
        {
            position = rayHit.point;
            player.RotateToPosition(position);
        }
    }
}
