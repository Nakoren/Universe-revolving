using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayState : MonoBehaviour
{
    [SerializeField] PauseState pauseState;
    [SerializeField] OpenMenuState openMenuState;
    [SerializeField] LevelEndState levelEndState;
    [SerializeField] DeathState deathState;
    [SerializeField] GameInstance gameInstance;
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] PlayerController playerController;

    [SerializeField] GameObject rootUI;
    private void OnEnable()
    {
        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Enable();
        }
        if (rootUI != null)
        {
            rootUI.SetActive(true);
        }
        playerController.onMenuSwitch += SwitchMenu;
        playerController.onPauseSwitch += SwitchPause;
    }

    private void OnDisable()
    {
        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Disable();
        }
        if (rootUI != null)
        {
            rootUI.SetActive(false);
        }
        playerController.onMenuSwitch -= SwitchMenu;
        playerController.onPauseSwitch -= SwitchPause; 
    }

    public void SwitchPause()
    {
        pauseState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void SwitchMenu()
    {
        openMenuState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void EndLevel()
    {
        levelEndState.gameObject.SetActive(true); 
        this.gameObject.SetActive(false);
    }
    public void OnDeath()
    {
        deathState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
