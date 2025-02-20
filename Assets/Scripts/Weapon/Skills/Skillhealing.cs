using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "healing", menuName = "Skills/healing")]
public class Skillhealing : ISkill
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
            Debug.Log("Skillhealing used");
            CoolldownDelay();
            
=======
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
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
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
<<<<<<< HEAD
        
        yield return new WaitForSeconds(cooldown);
        m_isCooldown = false;
=======
        yield return new WaitForSeconds(cooldown);
        m_isColdown = false;
>>>>>>> 8e4c492236835aa814af70bff0ed799e2e86f7fc
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delay);
    }
}