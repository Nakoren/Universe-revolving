using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveAction", story: "[Agent] move to [Target]", category: "Action", id: "920d252755cbb65702bb4a27d026e67e")]
public partial class MoveAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    private AgentMovement m_Movement;

    protected override Status OnStart()
    {
        if (Agent?.Value != null)
        {
            m_Movement = Agent.Value.GetComponent<AgentMovement>();
        }

        if (m_Movement == null)
        {
            Debug.LogWarning("Enemy component not found on Agent.");
            return Status.Failure;
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (Agent?.Value == null || Target?.Value == null)
        {
            return Status.Failure;
        }

        m_Movement.Move(Target.Value.position);
        return Status.Success;
    }


}