//using Unity.AppUI.UI;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseState : MonoBehaviour
{
    [SerializeField] GamePlayState gamePlayState;
    [SerializeField] OpenMenuState openMenuState;
    [SerializeField] SettingsState settingsState;
    [SerializeField] PlayerController playerController;
    
    [SerializeField] GameObject rootUI;


    private void OnEnable()
    {
        Time.timeScale=0f;

        if (rootUI != null)
        {
            rootUI.SetActive(true);
        }
        playerController.onPauseToogle += ToGamePlay;
    }

    private void OnDisable()
    {
        if (rootUI != null)
        {
            rootUI.SetActive(false);
        }
        playerController.onPauseToogle -= ToGamePlay;
    }

    public void ToGamePlay()
    {
        Debug.Log("Pause disabled");
        gamePlayState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ToMenu()
    {
        this.gameObject.SetActive(false);
        openMenuState.gameObject.SetActive(true);
    }

    public void ToSettings()
    {
        settingsState.previousState = this.gameObject;
        this.gameObject.SetActive(false);
        settingsState.gameObject.SetActive(true);
    }

}
