using Mono.Cecil;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private EnemyMove m_movement;
    private IAttack m_attack;
    private EnemyDash m_enemydash;

    public void Awake()
    {
        m_movement = GetComponent<EnemyMove>();

        if (TryGetComponent<RangeAttack>(out var rangeAttack))
        {
            m_attack = rangeAttack;
        }
        else if (TryGetComponent<MeleeAttack>(out var meleeAttack))
        {
            m_attack = meleeAttack;
        }
    }


    public void Move(Vector3 target)
    {
        m_movement.Move(target);
    }

    public void Attack(Vector3 target)
    {
        m_attack.Attack(target);
    }

    public void Dash(Vector3 target)
    {
        if (m_enemydash != null)
        {
            m_enemydash.StartDash(target);

        }

    }



}
