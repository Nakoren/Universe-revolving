using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "AttackAction", story: "[Agent] attacks [Target]", category: "Action", id: "cf055bbe845bc65ff969d3f7282f4040")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> agent;
    [SerializeReference] public BlackboardVariable<Transform> target;

    private AgentAttack m_attack;
    protected override Status OnStart()
    {
        if (agent?.Value != null)
        {
            m_attack = agent.Value.GetComponent<AgentAttack>();
        }

        if (m_attack == null)
        {
            return Status.Failure;
        }

        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (target == null)
        {
            return Status.Failure;
        }
        Vector3 targetPosition = target.Value.transform.position;

        if (m_attack == null)
        {
            return Status.Failure;
        }

        m_attack.Attack(targetPosition);
        return Status.Success; 
    }
}

