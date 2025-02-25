//using Unity.AppUI.UI;
using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PauseState : IState
{
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject cameraController;

    
    [SerializeField] GameObject rootUI;

    public Action onPause;


    override protected void OnEnter()
    {
        Time.timeScale=0f;

        if (rootUI != null)
        {
            rootUI.SetActive(true);
            cameraController.SetActive(false);
        }
        onPause?.Invoke();
    }

    override protected void OnExit()
    {
        if (rootUI != null)
        {
            rootUI.SetActive(false);
        }
    }
}
