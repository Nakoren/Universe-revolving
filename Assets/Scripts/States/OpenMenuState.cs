using UnityEngine;
using UnityEngine.UI;

public class OpenMenuState : MonoBehaviour
{
    [SerializeField] GamePlayState gameplayState;
    [SerializeField] SettingsState settingsState;

    [SerializeField] GameObject rootUI;

    private void OnEnable()
    {
        Time.timeScale=0f;
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

    public void ToGamePlay()
    {
        gameplayState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

     public void ToSetings()
    {
        settingsState.previousState = this.gameObject;
        settingsState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
