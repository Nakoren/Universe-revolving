using System;
using System.Collections;
using UnityEngine;

public class HealingSkill : MonoBehaviour
{
    [SerializeField] private float skillValue = 0.2f; 
    private bool isSkillOnCooldown = false;
    private float lastUsedTime = -Mathf.Infinity;

    public event Action<float> onCooldownTick;
    public event Action onCooldownComplete;

    public void StartHealingSkill(Health health, float cooldownTime)
    {
        if (isSkillOnCooldown)
        {
            Debug.Log("HealingSkill is on cooldown");
            return;
        }
        
        HealingSkillLogic(health);
        
        isSkillOnCooldown = true;
        lastUsedTime = Time.time;
        StartCoroutine(CooldownRoutine(cooldownTime, () =>
        {
            isSkillOnCooldown = false;
            onCooldownComplete?.Invoke();
        }));
    }

    private IEnumerator CooldownRoutine(float cooldownTime, Action onFinish)
    {
        float remainingTime = cooldownTime;
        while (remainingTime > 0f)
        {
            onCooldownTick?.Invoke(remainingTime);
            remainingTime -= Time.deltaTime;
            yield return null;
        }
        onFinish?.Invoke();
    }

    private void HealingSkillLogic(Health health)
    {
        float healAmount = health.GetMaxHealth() * skillValue;
        health.RestoreHealth(healAmount);
    }
}

