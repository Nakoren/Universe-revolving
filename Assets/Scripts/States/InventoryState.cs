using UnityEngine;

public class InventoryState : MonoBehaviour
{
    [SerializeField] GamePlayState gameplayState;
    [SerializeField] PlayerController playerController;

    [SerializeField] GameObject rootUI;

    private void OnEnable()
    {
        Time.timeScale=0f;

        if (rootUI != null)
        {
            rootUI.SetActive(true);
        }
        playerController.onInventoryToogle += ToGamePlay;
    }

    private void OnDisable()
    {
        if (rootUI != null)
        {
            rootUI.SetActive(false);
        }
        playerController.onInventoryToogle -= ToGamePlay; 
    }

    public void ToGamePlay()
    {
        gameplayState.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
   


    
}
