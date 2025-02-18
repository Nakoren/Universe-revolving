using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "boost", menuName = "Skills/boost")]
public class Skillboost : ISkill
{
    public bool m_isCooldown = false;
    public int cooldown = 2; // Для иконок перезарядки
    public void Awake()
    {
        m_isCooldown = false;
    }
    public override void OnSkillStart()
    {
        if (m_isCooldown == false)
        {
            m_isCooldown = true;
            Debug.Log("Skillboost used");
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
        m_isCooldown = false;
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
    }
}
