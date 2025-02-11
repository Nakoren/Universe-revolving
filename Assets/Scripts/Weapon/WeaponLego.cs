using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLego : MonoBehaviour
{
    private Weapon m_weapon;
    private List<ElementInfo> m_Elements = new List<ElementInfo>();
    public ElementsDB scope;
    public ElementsDB magazine;
    public ElementsDB receiver;

    public void Awake()
    {
        m_weapon = GetComponent<Weapon>(); 
    }

    public void GetElements()
    {
        // Очищаем список и собираем компоненты
        m_Elements.Clear();
        m_Elements.AddRange(GetComponentsInChildren<ElementInfo>());

        // Проверяем, были ли найдены компоненты
        if (m_Elements.Count > 0)
        {
            //Debug.Log("Найдено " + m_Elements.Count + " компонентов ElementInfo.");
            foreach (var element in m_Elements)
            {
                //Debug.Log("ElementInfo: " + element.name);
            }
        }
        else
        {
            //Debug.LogWarning("Компоненты ElementInfo не найдены в дочерних объектах.");
        }
        LegoSort();
    }

    public void LegoSort()
    {
        for (int i = 0; i < m_Elements.Count; i++)
        {
            if (m_Elements[i].elementDB.type == "scope")
            {
                scope = m_Elements[i].elementDB;
            }
            else if (m_Elements[i].elementDB.type == "magazine")
            {
                magazine = m_Elements[i].elementDB;
            }
            else if (m_Elements[i].elementDB.type == "receiver")
            {
                receiver = m_Elements[i].elementDB;
            }
        }
    }
}
