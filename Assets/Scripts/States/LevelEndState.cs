using UnityEngine;

public class LevelEndState : MonoBehaviour
{
    [SerializeField] GameInstance gameInstance;

    [SerializeField] GameObject rootUI;
    private void OnEnable()
    {
        if (rootUI != null)
        {
            rootUI.SetActive(true);
        }
    }

    private void OnDisable()
    {
        if (rootUI != null)
        {
            rootUI.SetActive(false);
        }
    }
    public void loadNextLevel()
    {

    }
}
