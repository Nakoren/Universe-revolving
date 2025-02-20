using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "boost", menuName = "Skills/boost")]
public class Skillboost : ISkill
{
<<<<<<< HEAD
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
=======
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
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
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
<<<<<<< HEAD
        m_isCooldown = false;
=======
        m_isColdown = false;
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
    }
}
