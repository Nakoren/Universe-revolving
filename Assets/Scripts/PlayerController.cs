using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Player player;
    public InputActionAsset inputActions;
    public TerrainCollider terrainCollider;
    public Transform cameraTransform;
    
    private InputAction m_moveAction;
    private InputAction m_useSkill1Action;
    private InputAction m_useSkill2Action;
    private InputAction m_extraAction;
    private InputAction m_dashAction;
    private InputAction m_fireAction;
    private InputAction m_extraFireAction;

    public event Action<Vector2> ActoinMovePlayer;
    public event Action ActoinDashPlayer;





    private void Awake()
    {
        m_moveAction = inputActions.FindAction("Player/Move");
        m_useSkill1Action = inputActions.FindAction("Player/Skill1");
        m_useSkill2Action = inputActions.FindAction("Player/Skill2");
        m_extraAction = inputActions.FindAction("Player/ExtraAction");
        m_dashAction = inputActions.FindAction("Player/Dash");

        m_fireAction = inputActions.FindAction("Player/Fire");
        m_extraFireAction = inputActions.FindAction("Player/ExtraFire");
    }

    void Start()
    {
        m_moveAction.Enable();
        m_useSkill1Action.Enable();
        m_useSkill1Action.started += OnSkill1;
        m_useSkill2Action.Enable();
        m_useSkill2Action.started += OnSkill2;
        m_extraAction.Enable();
        m_extraAction.started += OnExtraAction;
        m_dashAction.Enable();
        m_dashAction.started += OnDash;

        m_fireAction.Enable();
        m_fireAction.started += OnFireStarted;
        m_fireAction.canceled += OnFireEnded;

    }

    void Update()
    {
        RotateToCursor();
        MovePlayer();
    }

    private void RotateToCursor()
    {
        Vector3 position;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;


        if (terrainCollider.Raycast(ray, out rayHit, 1000))
        {
            position = rayHit.point;
            player.RotateTo(position);
        }
    }

    private void MovePlayer()
    {
        Vector3 cameraRotationV3 = cameraTransform.forward;
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        //Debug.Log(move);

        player.Move(move, cameraRotationV3);
        ActoinMovePlayer?.Invoke(move); 
    }

    private void OnSkill1(InputAction.CallbackContext context)
    {
        player.Skill1();
    }
    private void OnSkill2(InputAction.CallbackContext context)
    {
        player.Skill2();
    }

    private void OnExtraAction(InputAction.CallbackContext context)
    {
        player.ExtraAction();
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        Vector2 moveInput = m_moveAction.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            player.Dash(); // Логика движения рывка
            ActoinDashPlayer?.Invoke(); 
        }
    }

    private void OnFireStarted(InputAction.CallbackContext context)
    {
        player.StartFire();
    }

    private void OnFireEnded(InputAction.CallbackContext context)
    {
        player.StopFire();
    }

    // private static Vector3 RaycastToCursor()
    // {
    //     Debug.Log("FireStarted");

    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;

    //     Vector3 targetPoint;
    //     if (Physics.Raycast(ray, out hit))
    //         targetPoint = hit.point;
    //     else
    //         targetPoint = ray.GetPoint(75);
    //     return targetPoint;
    // }
    //Vector3 targetPoint = RaycastToCursor();
}
