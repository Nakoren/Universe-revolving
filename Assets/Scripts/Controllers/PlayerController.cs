using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Player player;
    public InputActionAsset inputActions;
    public TerrainCollider terrainCollider;
    public Transform cameraTransform;

    private InputActionMap playerActionMap;
    private InputActionMap UIActionMap;

    [NonSerialized] public Action onPauseSwitch;
    [NonSerialized] public Action onMenuSwitch;
    [NonSerialized] public Action onInventorySwitch;

    private InputAction m_moveAction;
    private InputAction m_useSkill1Action;
    private InputAction m_useSkill2Action;
    private InputAction m_extraAction;
    private InputAction m_dashAction;
    private InputAction m_fireAction;
    private InputAction m_extraFireAction;

    private InputAction m_switchPause;
    private InputAction m_switchMap;
    private InputAction m_switchInventory;


    private void Awake()
    {
        playerActionMap = inputActions.FindActionMap("Player");
        UIActionMap = inputActions.FindActionMap("UI");

        m_moveAction = inputActions.FindAction("Player/Move");
        m_useSkill1Action = inputActions.FindAction("Player/Skill1");
        m_useSkill2Action = inputActions.FindAction("Player/Skill2");
        m_extraAction = inputActions.FindAction("Player/ExtraAction");
        m_dashAction = inputActions.FindAction("Player/Dash");

        m_fireAction = inputActions.FindAction("Player/Fire");
        m_extraFireAction = inputActions.FindAction("Player/ExtraFire");

        m_switchPause = inputActions.FindAction("UI/Pause");
        m_switchMap = inputActions.FindAction("UI/Map");
        m_switchInventory = inputActions.FindAction("UI/Inventory");
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

        m_switchInventory.Enable();
        m_switchInventory.started += OnInventorySwitch;
        m_switchPause.Enable();
        m_switchPause.started += OnPauseSwitch;
        m_switchMap.Enable();
        m_switchMap.started += OnMapSwitch;
    }

    void Update()
    {
        RotateToCursor();
        MovePlayer();
    }

    private void RotateToCursor()
    {
        if (!(playerActionMap.enabled)) { return; }
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
        if (!(playerActionMap.enabled)) { return; }
        Vector3 cameraRotationV3 = cameraTransform.forward;
        Vector2 move = m_moveAction.ReadValue<Vector2>();
        //Debug.Log(move);
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
        Vector3 targetPoint = RaycastToCursor();

        player.Shoot();

    }

    private void onFireEnded(InputAction.CallbackContext context)
    {
        Debug.Log("FireEnded");
    }

    private static Vector3 RaycastToCursor()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);
        return targetPoint;
    }

    private void OnPauseSwitch(InputAction.CallbackContext context)
    {
        if (onPauseSwitch != null)
        {
            onPauseSwitch.Invoke();
        }
    }

    private void OnMapSwitch(InputAction.CallbackContext context)
    {
        if (onMenuSwitch != null)
        {
            onMenuSwitch.Invoke();
        }
    }

    private void OnInventorySwitch(InputAction.CallbackContext context)
    {
        if(onInventorySwitch!= null)
        {
            onInventorySwitch.Invoke();
        }
    }

    public void TooglePlayerInput(bool value)
    {
        if (value) 
        {
            playerActionMap.Enable();
        }
        else
        {
            playerActionMap.Disable();
        }
    }

    public void ToogleUIInput(bool value)
    {
        if (value)
        {
            UIActionMap.Enable();
        }
        else
        {
            UIActionMap.Disable();
        }
    }

}
