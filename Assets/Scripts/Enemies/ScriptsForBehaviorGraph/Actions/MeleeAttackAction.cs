using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "MeleeAttackAction", story: "[Agent] attacks [Target] (Melee)", category: "Action", id: "94dcabbacad881d43486ea869a1be53a")]
public partial class MeleeAttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<Transform> Target;
    [SerializeReference] public BlackboardVariable<GameObject> HitBox; 

    [Header("Attack Settings")]
    [SerializeReference] public BlackboardVariable<float> damage; 
    [SerializeReference] public BlackboardVariable<float> attackCooldown;

    

    private float lastAttackTime;
    private NavMeshAgent m_meshAgent;



    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

