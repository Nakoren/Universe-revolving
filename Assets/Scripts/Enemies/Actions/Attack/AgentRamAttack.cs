using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System;

public class AgentRamAttack : MonoBehaviour, IAttack
{
    private float lastRamTime;
    private NavMeshAgent m_meshAgent;

    [Header("Ram Attack Settings")]
    [SerializeField] private GameObject hitBox;
    [SerializeField] private float ramCooldown = 5f;
    [SerializeField] private float ramDuration = 2f;
    [SerializeField] private float ramSpeed = 9f;
    [SerializeField] private float rotationSpeedMultiplier = 0.5f;
    public event Action OnAgentAttack;

    private bool isRamming = false;

    event Action IAttack.AgentAttack
    {
        add
        {
            throw new NotImplementedException();
        }

        remove
        {
            throw new NotImplementedException();
        }
    }

    private void Awake()
    {
        m_meshAgent = GetComponent<NavMeshAgent>();
        hitBox.SetActive(false);
    }

    public void AgentAttack(Vector3 targetPosition)
    {
        if (isRamming || Time.time - lastRamTime < ramCooldown) return;

        StartCoroutine(PerformRamAttack(targetPosition));
        lastRamTime = Time.time;
    }

    private IEnumerator PerformRamAttack(Vector3 targetPosition)
    {
        isRamming = true;
        m_meshAgent.isStopped = true;

        float elapsedTime = 0f;

        // Поворот к цели
        while (elapsedTime < ramDuration)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;

            if (direction.sqrMagnitude > 0.01f)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * m_meshAgent.angularSpeed * rotationSpeedMultiplier);
            }

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Совершаем рывок
        if (hitBox != null)
        {
            hitBox.SetActive(true);
        }

        float dashElapsed = 0f;
        Vector3 dashDirection = transform.forward;

        while (dashElapsed < ramDuration)
        {
            transform.position += dashDirection * ramSpeed * Time.deltaTime;
            dashElapsed += Time.deltaTime;
            yield return null;
        }

        if (hitBox != null)
        {
            hitBox.SetActive(false);
        }

        isRamming = false;
        m_meshAgent.isStopped = false;
    }

    public void Attack(Vector3 target)
    {
        throw new NotImplementedException();
    }
}
