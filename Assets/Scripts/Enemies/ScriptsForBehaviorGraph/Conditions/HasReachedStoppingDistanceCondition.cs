using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Has Reached Stopping Distance", story: "[Agent] has reached stopping distance", category: "Variable Conditions", id: "a465d96284c2cfb0cfcb41c37cfa892c")]
public partial class HasReachedStoppingDistanceCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    private AgentMovement m_Movement;

    public override bool IsTrue()
    {
         if (Agent?.Value == null)
        {
            Debug.LogWarning("Agent is not set or not found.");
            return false;
        }

        // Получаем компонент AgentMovement
        m_Movement = Agent.Value.GetComponent<AgentMovement>();
        if (m_Movement == null)
        {
            Debug.LogWarning("AgentMovement component not found on the agent.");
            return false;
        }

        // Проверяем, достиг ли агент цели с помощью HasReachedDestination()
        bool hasReachedDestination = m_Movement.HasReachedDestination();
        Debug.Log($"Has Reached Destination: {hasReachedDestination}");
        return hasReachedDestination;

    
}
}