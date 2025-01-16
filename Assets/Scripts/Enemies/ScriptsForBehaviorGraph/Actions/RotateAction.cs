using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RotateOnly", story: "[Agent] rotate towards [Target]", category: "Action", id: "ad4cc8a3b09a366d22baabdda26f781c")]
public partial class RotateOnlyAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    private AgentRotation m_Rotation;

    protected override Status OnStart()
    {
        if (Agent?.Value != null)
        {
            m_Rotation = Agent.Value.GetComponent<AgentRotation>();
        }

        if (m_Rotation == null)
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
        m_Rotation.RotateTowardsTarget(Target.Value.position);
        return Status.Running;
    }


}
