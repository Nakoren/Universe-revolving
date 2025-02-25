using UnityEngine;

public abstract class IState: MonoBehaviour
{
    public void Enter() 
    {
        OnEnter();
    }

    virtual public void Activate()
    {
        gameObject.SetActive(true);
    }

    virtual public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void Exit()
    {
       OnExit();
    }

    protected abstract void OnEnter();

    protected abstract void OnExit();
}
