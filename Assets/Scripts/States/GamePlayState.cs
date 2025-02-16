using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePlayState : MonoBehaviour
{
    [SerializeField] PauseState pauseState;
    [SerializeField] OpenMenuState openMenuState;
    [SerializeField] LevelEndState levelEndState;
    [SerializeField] DeathState deathState;
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] InventoryState inventoryState;

    [SerializeField] PlayerController playerController;
    [SerializeField] Player player;

    [SerializeField] GameObject rootUI;

    public  Action onGamePlay;
    private void OnEnable()
    {
        Time.timeScale=1f;

        if (inputActions != null)
        {
            inputActions.FindActionMap("Player").Enable();
        }
        if (rootUI != null)
        {
            rootUI.SetActive(true);
        }
        onGamePlay?.Invoke();
        playerController.onInventoryToogle += ToogleInventory;

        playerController.onPauseToogle += TooglePause;

        player.onPlayerDeath += ToogleGameOver;
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
        playerController.onInventoryToogle -= ToogleInventory;
        playerController.onPauseToogle -= TooglePause; 

        player.onPlayerDeath -= ToogleGameOver;
    }

    private void ToogleGameOver()
    {
        deathState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void TooglePause()
    {
        pauseState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ToogleMenu()
    {
        openMenuState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ToogleInventory()
    {
        inventoryState.gameObject.SetActive(true);
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
