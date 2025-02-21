using System;
using Unity.Behavior;
using UnityEngine;
using UnityEngine.AI;

[Serializable, Unity.Properties.GeneratePropertyBag]
[Condition(name: "Agent has reached Player", story: "[Agent] has reached [Player]", category: "Variable Conditions", id: "33037636835aff6251d22644ac3f992f")]
public partial class AgentHasReachedPlayerCondition : Condition
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Player;

    private float distance;
    private Transform m_agentPosition;
    private Transform m_playerPosition;

    public override bool IsTrue()
    {
        NavMeshAgent m_meshAgent = Agent.Value.GetComponent<NavMeshAgent>();
        Transform m_agentPosition = Agent.Value.GetComponent<Transform>();
        Transform m_playerPosition = Player.Value.GetComponent<Transform>();
        distance = Vector3.Distance(m_agentPosition.position, m_playerPosition.position);


        if (distance <= m_meshAgent.stoppingDistance+1f)
        {
            Debug.LogWarning($"{Agent.Value.name}  {distance}");
            return true;
        }
        return false;
    }
}