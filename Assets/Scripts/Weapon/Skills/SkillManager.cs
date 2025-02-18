using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private ISkill[] skills;
    private ISkill m_skillQ;
    private ISkill m_skillE;

    private void Awake()
    {
        skills = GetComponentsInChildren<ISkill>();
        m_skillQ = skills[0];
        m_skillE = skills[1];
    }

    public void SkillQuse()
    {
        m_skillQ.OnSkillStart();
    }

    public void SkillEuse()
    {
        m_skillE.OnSkillStart();
    }
}
