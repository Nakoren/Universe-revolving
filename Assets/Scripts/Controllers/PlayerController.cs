using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Player player;
    private InteractableObjectDetector interactableObjectDetector;
    public InputActionAsset inputActions;
    public Collider terrainCollider;
    public Transform cameraTransform;

    private InputActionMap playerActionMap;
    private InputActionMap UIActionMap;

    [NonSerialized] public Action onPauseToogle;
    [NonSerialized] public Action onMenuToogle;
    [NonSerialized] public Action onInventoryToogle;

    private InputAction m_moveAction;
    private InputAction m_useSkill1Action;
    private InputAction m_useSkill2Action;
    private InputAction m_extraAction;
    private InputAction m_dashAction;
    private InputAction m_fireAction;
    private InputAction m_extraFireAction;
    private InputAction m_useAction;

    private InputAction m_switchPause;
    private InputAction m_switchMap;
    private InputAction m_switchInventory;

    public event Action<Vector2> PlayerMove;
    public event Action PlayerDash;
    public event Action ActoinOnSkill1Player;
    public event Action ActoinOnSkill2Player;


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

        m_useAction = inputActions.FindAction("Player/Use");

        interactableObjectDetector = player.gameObject.GetComponent<InteractableObjectDetector>();
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
        m_fireAction.started += OnFireStarted;
        m_fireAction.canceled += OnFireEnded;

        m_useAction.started += OnUse;
        m_switchInventory.Enable();
        m_switchInventory.started += OnInventoryToogle;
        m_switchPause.Enable();
        m_switchPause.started += OnPauseToogle;
        m_switchMap.Enable();
        m_switchMap.started += OnMapToogle;
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
        PlayerMove?.Invoke(move);
    }

    private void OnSkill1(InputAction.CallbackContext context)
    {
        player.Skill1();
        ActoinOnSkill1Player?.Invoke();
    }
    private void OnSkill2(InputAction.CallbackContext context) //nextweapon
    {
        player.Skill2();
        ActoinOnSkill2Player?.Invoke();
    }


    private void OnExtraAction(InputAction.CallbackContext context) //reload
    {
        player.ExtraAction();
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        Vector2 moveInput = m_moveAction.ReadValue<Vector2>();

        if (moveInput != Vector2.zero)
        {
            player.Dash(); // Логика движения рывка
            PlayerDash?.Invoke();
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

    private void OnUse(InputAction.CallbackContext context)
    {
        interactableObjectDetector.UseObject();
    }

    // private static Vector3 RaycastToCursor()
    // {
    //     Debug.Log("FireStarted");
    private static Vector3 RaycastToCursor()
    { return new Vector3(); }

    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;

    private void OnPauseToogle(InputAction.CallbackContext context)
    {
        if (onPauseToogle != null)
        {
            onPauseToogle.Invoke();
        }
    }

    private void OnMapToogle(InputAction.CallbackContext context)
    {
        if (onMenuToogle != null)
        {
            onMenuToogle.Invoke();
        }
    }

    private void OnInventoryToogle(InputAction.CallbackContext context)
    {
        if(onInventoryToogle!= null)
        {
            onInventoryToogle.Invoke();
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
