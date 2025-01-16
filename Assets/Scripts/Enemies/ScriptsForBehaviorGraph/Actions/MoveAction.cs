using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MoveAction", story: "[Agent] move to [Target]", category: "Action", id: "920d252755cbb65702bb4a27d026e67e")]
public partial class MoveAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    private NavMeshAgent m_meshAgent;
    private bool targetReached = false;

    protected override Status OnStart()
    {
        if (Agent?.Value != null)
        {
            m_meshAgent = Agent.Value.GetComponent<NavMeshAgent>();
        }

        if (m_meshAgent == null)
        {
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
        return MoveTo(Target.Value.position);
    }

    private Status MoveTo(Vector3 targetPosition)
    {
        m_meshAgent.destination = targetPosition;


        if (m_meshAgent.remainingDistance <= m_meshAgent.stoppingDistance)
        {
            if (!targetReached)
            {
                targetReached = true;
                Debug.Log("Agent reached the target.");
            }
            return Status.Success;
        }

        targetReached = false;
        Debug.Log("Agent is moving.");
        return Status.Running;
    }

}
