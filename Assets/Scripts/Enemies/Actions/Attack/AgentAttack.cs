using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class AgentAttack : MonoBehaviour
{
   public event Action<Vector3> OnAgentAttack;

    public void Attack(Vector3 targetPosition)
    {
        OnAgentAttack?.Invoke(targetPosition);
    }
}