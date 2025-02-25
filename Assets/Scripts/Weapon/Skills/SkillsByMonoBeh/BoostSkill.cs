using System;
using System.Collections;
using UnityEngine;

public class BoostSkill : MonoBehaviour
{
    [SerializeField] private float skillBoost = 0.2f; 
    [SerializeField] private float skillDuration = 5f;
    private bool isSkillOnCooldown = false;
    private float lastUsedTime = -Mathf.Infinity;

    public bool IsSkillOnCooldown => isSkillOnCooldown;

    public event Action<float> onCooldownTick;
    public event Action<float> onDurationSkill;
    public event Action onCooldownComplete;

    public void StartBoostSkill(Movement movement, float cooldownTime)
    {
        if (isSkillOnCooldown)
        {
            Debug.Log("BoostSkill is on cooldown");
            return;
        }

        float originalSpeed = movement.GetCurrentSpeed();
        BoostSkillLogic(movement);

       
        
        isSkillOnCooldown = true;
        lastUsedTime = Time.time;

        StartCoroutine(BoostThenCooldown(movement, originalSpeed, skillDuration, cooldownTime));
    }

    private IEnumerator BoostThenCooldown(Movement movement, float originalSpeed, float duration, float cooldownTime)
    {
        yield return StartCoroutine(BoostDurationCoroutine(movement, originalSpeed, duration));
        
        yield return StartCoroutine(CooldownRoutine(cooldownTime, () =>
        {
            isSkillOnCooldown = false;
            onCooldownComplete?.Invoke();
        }));
    }

    private IEnumerator BoostDurationCoroutine(Movement movement, float originalSpeed, float duration)
    {
        float remainingTime = duration;
        while (remainingTime>0f)
        {
            onDurationSkill?.Invoke(remainingTime);
            remainingTime -= Time.deltaTime;
            yield return null;
        }
        movement.SetCurrentSpeed((int)originalSpeed);
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

    private void BoostSkillLogic(Movement movement)
    {
        int moveAmount = (int) (movement.GetCurrentSpeed()* (1+skillBoost));
        movement.SetCurrentSpeed(moveAmount);
    }
}
