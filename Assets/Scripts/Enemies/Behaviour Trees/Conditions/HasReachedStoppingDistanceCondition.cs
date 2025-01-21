using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Has Reached Stopping Distance", story: "[Agent] has reached stopping distance", category: "Variable Conditions", id: "a465d96284c2cfb0cfcb41c37cfa892c")]
public partial class HasReachedStoppingDistanceCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;

    public override bool IsTrue()
    {
        if (Agent?.Value == null)
        {
            Debug.LogWarning("Agent is not set or not found.");
            return false;
        }

        NavMeshAgent m_meshAgent = Agent.Value.GetComponent<NavMeshAgent>();

        if (m_meshAgent == null)
        {
            Debug.LogWarning("NavMeshAgent component not found on the agent.");
            return false;
        }

        if (m_meshAgent.remainingDistance <= m_meshAgent.stoppingDistance /*&& !navMeshAgent.pathPending*/)
        {
            Debug.Log("Agent has reached stopping distance.");
            return true;
        }
        return false;
    }
}