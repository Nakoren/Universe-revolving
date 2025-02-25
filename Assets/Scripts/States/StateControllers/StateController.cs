using UnityEngine;
using static StateController;
using UnityEngine.InputSystem.LowLevel;

public class StateController : MonoBehaviour
{
    protected StateActivator m_stateActivator;

    private void Awake()
    {
        m_stateActivator = new StateActivator();
    }

    private void Start()
    {
        m_stateActivator = new StateActivator();
        var states = GetComponentsInChildren<IState>(true);
        foreach (var state in states)
        {
            m_stateActivator.Add(state);
        }

        m_stateActivator.Activate<GamePlayState>();
    }

    protected private void OnDestroy()
    {
        m_stateActivator.current.Deactivate();
        m_stateActivator.current.Exit();
    }

    virtual public void Back()
    {
        m_stateActivator.Back();
    }
}
