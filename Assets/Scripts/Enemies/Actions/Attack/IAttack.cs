using System;
using UnityEngine;

public interface IAttack
{
   public event Action AgentAttack;
    void Attack(Vector3 target);
}

