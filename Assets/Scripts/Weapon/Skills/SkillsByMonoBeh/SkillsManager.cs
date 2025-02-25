using System;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    [Header("Healing Skill Settings")]
    [SerializeField] private HealingSkill healingSkill;
    [SerializeField] private float healingSkillCooldown = 10f;

    [Header("Boost Skill Settings")]
    [SerializeField] private BoostSkill boostSkill;
    [SerializeField] private float boostSkillCooldown = 10f;
    
    private Health playerHealth;
    private Movement playerMovement;

    public Action OnHealingCooldown;
    public Action OnBoostCooldown;

    public bool IsHealingOnCooldown
    {
        get { return healingSkill != null && healingSkill.IsSkillOnCooldown; }
    }
    public bool IsBoostOnCooldown
    {
        get { return boostSkill != null && boostSkill.IsSkillOnCooldown; }
    }

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        playerMovement = GetComponent<Movement>();
    }


    public void ActivateHealingSkill()
    {
        if (healingSkill != null && playerHealth != null)
        {
            healingSkill.StartHealingSkill(playerHealth, healingSkillCooldown);
            OnHealingCooldown?.Invoke();
        }
    }

    public void ActivateBoostSkill()
    {
        if (boostSkill != null && playerHealth != null)
        {
            boostSkill.StartBoostSkill(playerMovement, boostSkillCooldown);
            OnBoostCooldown?.Invoke();
        }
    }
}
