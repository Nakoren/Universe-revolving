using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "healing", menuName = "Skills/healing")]
public class Skillhealing : ISkill
{
    public void Awake()
    {
        m_isColdown = false;
    }
    public override void OnSkillStart()
    {
        if (m_isColdown == false)
        {
            Debug.Log("Skillhealing used");
            m_isColdown = true;
            CoolldownDelay();
        }
        else 
        {
            Debug.Log("Skillhealing isColdown");
        }
    }
    public override void OnSkillEnd()
    {
        
    }
    private IEnumerator CoolldownDelay()
    {
        yield return new WaitForSeconds(cooldown);
        m_isColdown = false;
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
    }
}