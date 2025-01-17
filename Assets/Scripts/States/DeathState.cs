using UnityEngine;

public class DeathState : MonoBehaviour
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

    public void Restart()
    {

    }
    public void ToMenu()
    {

    }
}
