using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "RotateOnly", story: "[Agent] rotate towards [Target]", category: "Action", id: "ad4cc8a3b09a366d22baabdda26f781c")]
public partial class RotateOnlyAction : Action
{
    [SerializeReference] public BlackboardVariable<Transform> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    [SerializeReference] public BlackboardVariable<float> m_RotationSpeed;

    private NavMeshAgent m_meshAgent;

    protected override Status OnStart()
    {
        if (Agent?.Value != null)
        {
            m_meshAgent = Agent.Value.GetComponent<NavMeshAgent>();
            if (m_meshAgent != null)
            {

            }
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
        RotateTowardsTarget(Target.Value.position);
        return Status.Running;
    }

    private void RotateTowardsTarget(Vector3 targetPosition)
    {
        m_meshAgent.updateRotation = true;
        Transform m_currentTransform = Agent.Value.GetComponent<Transform>();


        Vector3 directionToTarget = (targetPosition - m_currentTransform.position).normalized;

        if (m_meshAgent.remainingDistance <= m_meshAgent.stoppingDistance && directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            m_currentTransform.rotation = Quaternion.Slerp(m_currentTransform.rotation, targetRotation, m_RotationSpeed * Time.deltaTime);
        }
    }
}
