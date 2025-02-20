using UnityEngine;

public class SkillManager : MonoBehaviour
{

    // private ISkill[] skills;
    public ISkill skillQ;
    public ISkill skillE;

    // private void Awake()
    // {
    //     skills = GetComponentsInChildren<ISkill>();
    //     m_skillQ = skills[0];
    //     m_skillE = skills[1];
    // }

    public void SkillQuse()
    {
        skillQ.OnSkillStart();

    }

    public void SkillEuse()
    {
        skillE.OnSkillStart();
    }
}
