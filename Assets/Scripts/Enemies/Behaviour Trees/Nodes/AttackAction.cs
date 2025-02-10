using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "AttackAction", story: "[Agent] attacks [Target]", category: "Action", id: "cf055bbe845bc65ff969d3f7282f4040")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;

    private Enemy m_enemy;
    protected override Status OnStart()
    {
        if (Agent?.Value != null)
        {
            m_enemy = Agent.Value.GetComponent<Enemy>();
        }

        if (m_enemy == null)
        {
            Debug.LogWarning("No Enemy component found on Agent.");
            return Status.Failure;
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector3 targetPosition = Target.Value.transform.position;

        if (m_enemy == null)
        {
            return Status.Failure;
        }

        m_enemy.Attack();
        return Status.Success; 
    }
}

