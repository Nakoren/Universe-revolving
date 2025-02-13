using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System;

public class SkillsManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Color cooldownColor = new Color(0f, 0f, 0f);

    [SerializeField] private Image skill1Icon;
    [SerializeField] private Image skill2Icon;
    [SerializeField] private TextMeshProUGUI skill1TimerText;
    [SerializeField] private TextMeshProUGUI skill2TimerText;

    private float skillCooldownTime = 10f; //не тут это должно быть
    private Color originalColor;
    private bool isSkill1OnCooldown = false; 
    private bool isSkill2OnCooldown = false;

    private void Awake()
    {
        originalColor = skill1Icon.color;
    }

    private void OnEnable()
    {
        playerController.ActoinOnSkill1Player += StartSkill1Cooldown;
        playerController.ActoinOnSkill2Player += StartSkill2Cooldown;
    }

    private void OnDisable()
    {
        playerController.ActoinOnSkill1Player -= StartSkill1Cooldown;
        playerController.ActoinOnSkill2Player -= StartSkill2Cooldown;
    }



    private void StartSkill2Cooldown()
    {
        if (!isSkill2OnCooldown)
        {
            isSkill2OnCooldown = true;
            StartCoroutine(CooldownRoutine(skill2Icon, skill2TimerText, () => isSkill2OnCooldown = false));
        }
    }

    private void StartSkill1Cooldown()
    {
        if (!isSkill1OnCooldown)
        {
            isSkill1OnCooldown = true;
            StartCoroutine(CooldownRoutine(skill1Icon, skill1TimerText, () => isSkill1OnCooldown = false));
        }
    }

    private IEnumerator CooldownRoutine(Image icon, TextMeshProUGUI timerText, Action onFinish)
    {
        icon.color = originalColor;
        timerText.enabled = true;

        float remainingTime = skillCooldownTime;
        while (remainingTime > 0f)
        {
            remainingTime -= Time.deltaTime;
            icon.color = cooldownColor;
            timerText.text = Mathf.CeilToInt(remainingTime).ToString();
            yield return null;
        }

        icon.color = originalColor;
        timerText.enabled = false;
        onFinish?.Invoke();
    }
}
