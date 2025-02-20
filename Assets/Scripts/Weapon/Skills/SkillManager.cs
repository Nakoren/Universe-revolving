using UnityEngine;

public class SkillManager : MonoBehaviour
{
<<<<<<< HEAD
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
=======
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
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
    }

    public void SkillEuse()
    {
<<<<<<< HEAD
        m_skillE.OnSkillStart();
=======
        skillE.OnSkillStart();
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
    }
}
