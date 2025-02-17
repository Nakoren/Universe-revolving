using System.Collections;
using UnityEngine;

public abstract class ISkill : ScriptableObject
{
    public bool m_isColdown = false;
    public int cooldown; // Для иконок перезарядки
    public int delay;
    public abstract void OnSkillStart();
    public abstract void OnSkillEnd();
}
