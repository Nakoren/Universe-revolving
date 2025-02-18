using System.Collections;
using UnityEngine;

public abstract class ISkill : MonoBehaviour
{
    // public bool m_isCooldown = false;
    // public int cooldown; // Для иконок перезарядки
    public int delay;
    public abstract void OnSkillStart();
    public abstract void OnSkillEnd();
}
