using UnityEngine;

public class OpenMenuState : MonoBehaviour
{
    [SerializeField] GamePlayState gameplayState;
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

    public void ToogleMenu()
    {
        gameplayState.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
