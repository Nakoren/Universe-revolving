using Unity.AppUI.UI;
using UnityEngine;

public class DeathState : IState
{
    [SerializeField] GameObject rootUI;
    [SerializeField] GamePlayState gamePlayState;
     [SerializeField] OpenMenuState openMenuState;


    override protected void OnEnter()
    {
        if (rootUI != null)
        {
            Time.timeScale=0f;
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

    public void ToMenu()
    {
        this.gameObject.SetActive(false);
        openMenuState.gameObject.SetActive(true);
    }
}
