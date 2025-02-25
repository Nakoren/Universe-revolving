using UnityEngine;
using static StateController;

public class GameStateController : StateController
{
    [SerializeField] PlayerController playerController;
    [SerializeField] LevelController levelController;
    private void Awake()
    {
        m_stateActivator = new StateActivator();
    }

    private void Start()
    {
        playerController.onPauseToogle += OnEscButton;
        playerController.onInventoryToogle += GoToInventory;
        playerController.player.onPlayerDeath += GoToDeath;
        levelController.onLevelFinish += GoToEndLevel;
        var states = GetComponentsInChildren<IState>(true);
        foreach (var state in states)
        {
            m_stateActivator.Add(state);
        }

        m_stateActivator.Activate<GamePlayState>();
    }

    public void OnEscButton()
    {
        if (!((m_stateActivator.current is PauseState) || (m_stateActivator.current is InventoryState) || (m_stateActivator.current is SettingsState)))
        {
            m_stateActivator.Push<PauseState>();
        }
        else
        {
            m_stateActivator.Back();
        }
    }
    public void GoToGamePlay()
    {
        m_stateActivator.Activate<GamePlayState>();
    }
    public void GoToEndLevel()
    {
        m_stateActivator.Push<LevelEndState>();
    }
    public void GoToSettings()
    {
        m_stateActivator.Push<SettingsState>();
    }
    
    public void GoToInventory()
    {
        if (!(m_stateActivator.current is InventoryState))
        {
            m_stateActivator.Push<InventoryState>();
        }
        else
        {
            m_stateActivator.Back();
        }
    }
    public void GoToDeath()
    {
        m_stateActivator.Push<DeathState>();
    }

    public void GoToMenu()
    {

    }
}
