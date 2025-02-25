using UnityEngine;

public class InventoryState : IState
{
    [SerializeField] PlayerController playerController;

    [SerializeField] GameObject rootUI;

    override protected void OnEnter()
    {
        Time.timeScale=0f;

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
