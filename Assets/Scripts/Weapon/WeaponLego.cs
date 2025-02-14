using System;
using System.Collections.Generic;
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
    public ElementsDB scope;
    public ElementsDB magazine;
    public ElementsDB receiver;
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
    // public void Pickup(ElementInfo elementInfo)
    // {  
    //     // Проверяем, есть ли уже дочерний объект с компонентом ScopeElement
    //     ElementInfo[] elementList = m_weapon.GetComponentsInChildren<ElementInfo>();
    //     m_existingElement.AddRange(elementList);
        
    //         if (m_existingElement != null)
    //         {
    //             for ( int i = 0; i < m_existingElement.Count; i++ )
    //             {
    //                 if (m_existingElement[i].elementDB.type == m_element.elementDB.type)
    //                 {
    //                     // Создаем новый объект PickupObjectInfo рядом с игроком
    //                     PickupObject pickupObject_new = Instantiate(pickupObjectPrefab, m_player.transform.position + Vector3.forward, Quaternion.identity);
    //                     pickupObject_new.GetPlayer(m_player);
    //                     pickupObject_new.GetInfo(m_existingElement[i]);

    //                     // Удаляем старый объект
    //                     Destroy(m_existingElement[i].gameObject);
    //                 }
    //             }
    //         }
    //                 // Создаем новый объект Scope как дочерний объект Weapon
    //                 var new_element = Instantiate(m_element, m_weapon.transform);
    //                 new_element.transform.localPosition = Vector3.zero; // Устанавливаем позицию объекта в (0, 0, 0) относительно Weapon
    //                 Weapon weapo = m_weapon.GetComponentInChildren<Weapon>();
    //                 weapo.GetElements();
    //                 // Удаляем объект PickupObject
    //                 Destroy(gameObject);
    // }
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
