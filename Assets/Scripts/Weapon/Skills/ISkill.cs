using System.Collections;
using UnityEngine;

<<<<<<< HEAD
public abstract class ISkill : MonoBehaviour
{
    // public bool m_isCooldown = false;
    // public int cooldown; // Для иконок перезарядки
=======
public abstract class ISkill : ScriptableObject
{
    public bool m_isColdown = false;
    public int cooldown; // Для иконок перезарядки
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
    public int delay;
    public abstract void OnSkillStart();
    public abstract void OnSkillEnd();
}
