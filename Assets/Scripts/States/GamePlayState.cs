using UnityEngine;

public class GamePlayState : MonoBehaviour
{
    [SerializeField] PauseState pauseState;
    [SerializeField] OpenMenuState openMenuState;
    [SerializeField] LevelEndState levelEndState;
    [SerializeField] DeathState deathState;
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

    public void TooglePause()
    {
        pauseState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void ToogleMenu()
    {
        openMenuState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void EndLevel()
    {
        levelEndState.gameObject.SetActive(true); 
        this.gameObject.SetActive(false);
    }
    public void OnDeath()
    {
        deathState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
