using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OpenMenuState : IState
{
    [SerializeField] InputActionAsset inputActions;

    [SerializeField] GameObject rootUI;

    override protected void OnEnter()
    {
        Time.timeScale=0f;

        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Disable();
        }

        if (rootUI != null)
        {
            rootUI.SetActive(true);
        }
    }

    override protected void OnExit()
    {
        if (rootUI != null)
        {
            rootUI.SetActive(false);
        }
    }
}
