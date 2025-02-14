using System;
using System.Collections.Generic;
using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponLego : MonoBehaviour
{
    private Weapon m_weapon;
    // public ElementsDB base_scope;
    // public ElementsDB base_magazine;
    // public ElementsDB base_receiver;
    public List<ElementsDB> basis = new List<ElementsDB>();
    private List<ElementInfo> m_Elements = new List<ElementInfo>();
    public Scope scope;
    public Magazine magazine;
    public Receiver receiver;
    public float totalDamage;

    public void Awake()
    {
        m_weapon = GetComponent<Weapon>(); 
    }

    public void GoBase()
    {
        for (int i = 0; i < m_Elements.Count; i++)
        {
            m_Elements[i].elementDB = basis[i];
        }
        GetElements();
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
        totalDamage = 20 * scope.damageRate * magazine.damageRate * receiver.damageRate;

    }
    public void Pickup(IPart part)
    {  
        if (part.type == 1)
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
