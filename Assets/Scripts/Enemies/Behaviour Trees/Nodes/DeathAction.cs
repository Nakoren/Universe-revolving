using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DeathAction", story: "[Agent] die", category: "Action", id: "d02718ec7105fa98bd54ca5cc0f03729")]
public partial class DeathAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;

   private AgentDeath agentDeath;

    protected override Status OnStart()
    {
        if (Agent?.Value == null)
        {
            return Status.Failure;
        }

        agentDeath = Agent.Value.GetComponent<AgentDeath>();
        if (agentDeath == null)
        {
            Debug.LogWarning("[DeathAction]: AgentDeath component not found on Agent.");
            return Status.Failure;
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (agentDeath != null)
        {
            agentDeath.Die();
            return Status.Success;
        }

        return Status.Failure;
    }
}

