using UnityEngine;

public class SettingsState : MonoBehaviour
{
    [SerializeField] PauseState pauseState;
    [SerializeField] private OpenMenuState openMenuState;

    [SerializeField] GameObject rootUI;

    public GameObject previousState;


    private void OnEnable()
    {
        Time.timeScale = 0f;

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

    public void ExitSettings()
    {
        if (previousState == pauseState.gameObject)
        {
            pauseState.gameObject.SetActive(true);
        }
        else if (previousState == openMenuState.gameObject)
        {
            openMenuState.gameObject.SetActive(true);
        }
        this.gameObject.SetActive(false);
    }
}


