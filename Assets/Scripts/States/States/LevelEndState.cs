using UnityEngine;

public class LevelEndState : IState
{
    [SerializeField] GameObject rootUI;
    override protected void OnEnter()
    {
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
    public void loadNextLevel()
    {

    }

    public void toMenu()
    {

    }
}
