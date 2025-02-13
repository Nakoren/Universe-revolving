using Unity.AppUI.UI;
using UnityEngine;

public class DeathState : MonoBehaviour
{
    [SerializeField] GameObject rootUI;
    [SerializeField] GamePlayState gamePlayState;
     [SerializeField] OpenMenuState openMenuState;


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
        this.gameObject.SetActive(false);
        gamePlayState.gameObject.SetActive(true);
    }
    public void ToMenu()
    {
        this.gameObject.SetActive(false);
        openMenuState.gameObject.SetActive(true);
    }
}
