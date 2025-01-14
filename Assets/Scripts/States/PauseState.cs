using UnityEditor;
using UnityEngine;

public class PauseState : MonoBehaviour
{
    [SerializeField] GamePlayState gamePlayState;
    [SerializeField] PlayerController playerController;
    
    [SerializeField] GameObject rootUI;

    private void Awake()
    {
        
    }
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
        gamePlayState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void ToMenu()
    {

    }
}
