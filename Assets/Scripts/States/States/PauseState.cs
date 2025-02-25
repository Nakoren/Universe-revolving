//using Unity.AppUI.UI;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseState : IState
{
    [SerializeField] PlayerController playerController;
    [SerializeField] CameraController cameraController;
    [SerializeField] InputActionAsset inputActions;
    public Action onPause;


    override protected void OnEnter()
    {
        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Disable();
        }
        onPause?.Invoke();
    }

    override protected void OnExit()
    {
        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Enable();
        }
    }
    public void toMenu()
    {

    }
}
