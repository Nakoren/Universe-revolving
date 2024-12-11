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


    private void Awake()
    {
        m_moveAction = inputActions.FindAction("Player/Move");
        m_useSkill1Action = inputActions.FindAction("Player/Skill1");
        m_useSkill2Action = inputActions.FindAction("Player/Skill2");
        m_extraAction = inputActions.FindAction("Player/ExtraAction");
        m_dashAction = inputActions.FindAction("Player/Dash");

        m_fireAction = inputActions.FindAction("Player/Fire");
        m_extraFireAction = inputActions.FindAction("Player/Fire");
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
        m_fireAction.started += onFireStarted;
        m_fireAction.canceled += onFireEnded;

        m_extraFireAction.Enable();
        m_extraFireAction.started += onExtraFireStarted;
        m_extraFireAction.canceled += onExtraFireEnded;
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
            player.RotateToPosition(position);
        }
    }

    private void MovePlayer()
    {
        Vector3 cameraRotationV3 = cameraTransform.forward;
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        player.Move(move, cameraRotationV3);
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
        player.Dash();
    }

    private void onFireStarted(InputAction.CallbackContext context)
    {
        
    }

    private void onFireEnded(InputAction.CallbackContext context)
    {
        
    }

    private void onExtraFireStarted(InputAction.CallbackContext context)
    {
        
    }

    private void onExtraFireEnded(InputAction.CallbackContext context)
    {
        
    }

}
