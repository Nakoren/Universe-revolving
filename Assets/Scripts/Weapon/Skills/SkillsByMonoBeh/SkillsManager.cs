using UnityEngine;

public class SkillsManager : MonoBehaviour
{
    [Header("Healing Skill Settings")]
    [SerializeField] private HealingSkill healingSkill; 
    [SerializeField] private float healingSkillCooldown = 180f; 
    [SerializeField] private Health playerHealth; 

    
    public void ActivateHealingSkill()
    {
        if (healingSkill != null && playerHealth != null)
        {
            healingSkill.StartHealingSkill(playerHealth, healingSkillCooldown);
        }
    }
}
