using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Has Reached Stopping Distance", story: "[Agent] has reached stopping distance", category: "Variable Conditions", id: "a465d96284c2cfb0cfcb41c37cfa892c")]
public partial class HasReachedStoppingDistanceCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Player;


    public override bool IsTrue()
    {
        if (Agent?.Value == null)
        {
            Debug.LogWarning("Agent is not set or not found.");
            return false;
        }

        NavMeshAgent m_meshAgent = Agent.Value.GetComponent<NavMeshAgent>();

        Transform m_agentPosition =Agent.Value.GetComponent<Transform>();
        Transform m_playerPosition =Player.Value.GetComponent<Transform>();
        float distance = Vector3.Distance(m_agentPosition.position, m_playerPosition.position);

        if (m_meshAgent == null)
        {
            Debug.LogWarning("NavMeshAgent component not found on the agent.");
            return false;
        }
        

        if (distance <= m_meshAgent.stoppingDistance/*&& !navMeshAgent.pathPending*/)
        {
            Debug.Log($"Agent has reached stopping distance. Velocity {m_meshAgent.velocity.magnitude}");
            return true;
        }
        return false;
    }
}