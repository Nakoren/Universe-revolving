using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "boost", menuName = "Skills/boost")]
public class Skillboost : ISkill
{
    public void Awake()
    {
        m_isColdown = false;
    }
    public override void OnSkillStart()
    {
        if (m_isColdown == false)
        {
            Debug.Log("Skillboost used");
            m_isColdown = true;
            CoolldownDelay();
        }
        else 
        {
            Debug.Log("Skillboost isColdown");
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
