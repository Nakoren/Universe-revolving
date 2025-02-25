using UnityEngine;
using static StateController;

public class GameStateController : StateController
{
    public void GoToPause()
    {
        m_stateActivator.Push<DeathState>();
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
        m_stateActivator.Push<InventoryState>();
    }
    public void GoToDeath()
    {
        m_stateActivator.Push<DeathState>();
    }
}
