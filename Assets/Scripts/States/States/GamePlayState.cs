using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayState : IState
{
    [SerializeField] InputActionAsset inputActions;

    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject cameraController;
    [SerializeField] Player player;

    [SerializeField] GameObject rootUI;

    public Action onGamePlay;
    override protected void OnEnter()
    {
        Time.timeScale=1f;

        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Enable();
        }
        if (rootUI != null)
        {
            rootUI.SetActive(true);
            cameraController.SetActive(true);
        }
        onGamePlay?.Invoke();
    }

    override protected void OnExit()
    {
        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Disable();
        }
        if (rootUI != null)
        {
            rootUI.SetActive(false);
        }
    }
}
