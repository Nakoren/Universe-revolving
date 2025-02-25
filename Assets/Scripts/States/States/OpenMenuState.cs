using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OpenMenuState : IState
{
    [SerializeField] InputActionAsset inputActions;

    override protected void OnEnter()
    {
        Time.timeScale=0f;

        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Disable();
        }
    }

    override protected void OnExit()
    {

    }
}
