using UnityEngine;

public class InventoryState : IState
{
    [SerializeField] PlayerController playerController;

    override protected void OnEnter()
    {
        Time.timeScale=0f;

    }

    override protected void OnExit()
    {
        Time.timeScale = 1f;
    }
}
