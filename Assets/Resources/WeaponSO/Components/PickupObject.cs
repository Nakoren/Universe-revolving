using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    ElementInfo m_element;
    public GameObject scopePrefab; // Префаб для объекта Scope
    public GameObject weapon; // Ссылка на объект Weapon
    public PickupObject pickupObjectPrefab; // Префаб для объекта PickupObjectInfo
    public Transform player; // Ссылка на игрока для позиционирования
    private List<ElementInfo> m_existingElement = new List<ElementInfo>();

    public void Awake()
    {
        m_element = GetComponentInChildren<ElementInfo>();
    }
    public void GetInfo(ElementInfo info)
    {
        m_element.GetInfo(info.elementDB);
        //m_element.elementDB
    }
    public void Interact()
    {
        
    }
    public void Pickup()
    {
        // Проверяем, есть ли уже дочерний объект с компонентом ScopeElement
        m_existingElement.AddRange(weapon.GetComponentsInChildren<ElementInfo>());
        
            if (m_existingElement != null)
            {
                for ( int i = 0; i < m_existingElement.Count; i++ )
                {
                    if (m_existingElement[i].elementDB.type == m_element.elementDB.type)
                    {
                        // Создаем новый объект PickupObjectInfo рядом с игроком
                        PickupObject pickupObject_new = Instantiate(pickupObjectPrefab, player.position + Vector3.forward, Quaternion.identity);
                        pickupObject_new.GetInfo(m_existingElement[i]);

                        // Удаляем старый объект
                        Destroy(m_existingElement[i].gameObject);
                    }
                }
            }
                    // Создаем новый объект Scope как дочерний объект Weapon
                    var new_element = Instantiate(m_element, weapon.transform);
                    new_element.transform.localPosition = Vector3.zero; // Устанавливаем позицию объекта в (0, 0, 0) относительно Weapon
                    Weapon weapo = weapon.GetComponentInChildren<Weapon>();
                    weapo.GetElements();
                    // Удаляем объект PickupObject
                    Destroy(gameObject);
    }

    void Update()
    {
        // Проверяем, была ли нажата левая кнопка мыши
        if (Input.GetMouseButtonDown(0))
        {
            // Создаем луч из камеры
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Проверяем, попал ли луч на объект PickupObject
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    Pickup();
                }
            }
        }
    }
}
