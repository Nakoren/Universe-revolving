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

    private IAttack m_Attack;
    protected override Status OnStart()
    {
        if (Agent?.Value != null)
        {
            m_Attack = Agent.Value.GetComponent<IAttack>();
        }

        if (m_Attack == null)
        {
            Debug.LogWarning("No Enemy component found on Agent.");
            return Status.Failure;
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Vector3 targetPosition = Target.Value.transform.position;

        if (m_Attack == null)
        {
            return Status.Failure;
        }

        m_Attack.Attack(targetPosition);
        return Status.Running; 
    }
}

