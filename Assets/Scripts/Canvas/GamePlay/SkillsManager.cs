using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using System;

/*public class SkillsManager : MonoBehaviour
{
    [SerializeField] private Player player;
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
        player.onPlayerSkill1 += StartSkill1Cooldown;
        player.onPlayerSkill2 += StartSkill2Cooldown;
    }

    private void OnDisable()
    {
        player.onPlayerSkill1 += StartSkill1Cooldown;
        player.onPlayerSkill2 += StartSkill2Cooldown;
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
}*/


public class SkillCooldownDisplay : MonoBehaviour
{
    [SerializeField] private Color cooldownColor = new Color(0f, 0f, 0f);
    [SerializeField] private Slider durationSlider;
    private Color originalColor;

    [SerializeField] private HealingSkill healingSkill;
    [SerializeField] private TextMeshProUGUI healingTimerText;
    [SerializeField] private Image healingSkillIcon;

    [SerializeField] private BoostSkill boostSkill;
    [SerializeField] private TextMeshProUGUI boostTimerText;
    [SerializeField] private Image boostSkillIcon;


    private void Awake()
    {
        originalColor = healingSkillIcon.color;
        originalColor = boostSkillIcon.color;
    }

    private void OnEnable()
    {
        healingSkill.onCooldownTick += UpdateHealingCooldownText;
        healingSkill.onCooldownComplete += ClearHealingCooldownText;

        boostSkill.onCooldownTick += UpdateBoostCooldownText;
        boostSkill.onCooldownComplete += ClearBoostCooldownText;
        boostSkill.onDurationSkill += UpdateBoostDurationText;


    }

    private void OnDisable()
    {
        healingSkill.onCooldownTick -= UpdateHealingCooldownText;
        healingSkill.onCooldownComplete -= ClearHealingCooldownText;

        boostSkill.onCooldownTick -= UpdateBoostCooldownText;
        boostSkill.onCooldownComplete -= ClearBoostCooldownText;
    }


    private void UpdateHealingCooldownText(float remainingTime)
    {
        healingSkillIcon.color = cooldownColor;
        healingTimerText.text = Mathf.CeilToInt(remainingTime).ToString();

    }

    private void ClearHealingCooldownText()
    {
        healingSkillIcon.color = originalColor;
        healingTimerText.text = "";

    }
    private void UpdateBoostDurationText(float remainingTime)
    {
        durationSlider.value = remainingTime/boostSkill.SkillDuration;
    }


    private void UpdateBoostCooldownText(float remainingTime)
    {
        boostSkillIcon.color = cooldownColor;
        boostTimerText.text = Mathf.CeilToInt(remainingTime).ToString();
    }


    private void ClearBoostCooldownText()
    {
        boostSkillIcon.color = originalColor;
        boostTimerText.text = "";
    }
}

