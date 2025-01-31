using System;
using Unity.Behavior;
using UnityEngine;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "HasReachedZeroHealthCondition", story: "[Agent] has reached zero [Health]", category: "Variable Conditions", id: "d12bb4c4404098427dafd1d252557918")]
public partial class HasReachedZeroHealthCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Health> Health;

    public override bool IsTrue()
    {
        if (Health == null)
        {
            Debug.LogWarning("[HasReachedHealthZeroCondition]: Health component not found on the agent.");
            return false;
        }

        if (Health.Value.GetCurrentHealth() <= 0)
        {
            Debug.Log($"[HasReachedHealthZeroCondition]: Agent's health has reached zero {Health.Value.GetCurrentHealth()}.");
            return true;
        }
        //Debug.Log($"[HasReachedHealthZeroCondition]: Agent's health has reached zero {Health.Value.GetCurrentHealth()}.");

        return false;
    }

}



