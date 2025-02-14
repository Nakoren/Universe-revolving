using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupObject : IInteractable
{
    ElementInfo m_element;
    // private Weapon m_weapon; // Ссылка на объект Weapon
    // public PickupObject pickupObjectPrefab; // Префаб для объекта PickupObjectInfo
    // private Player m_player;
    // public Player Player {set{m_player = value;}} // Ссылка на игрока для позиционирования
    // private List<ElementInfo> m_existingElement = new List<ElementInfo>();

    public void Awake()
    {
        m_element = GetComponentInChildren<ElementInfo>();
        // if (m_player != null)
        // {
        //     m_weapon = m_player.GetComponentInChildren<Weapon>();
        // }
    }
    // public void GetPlayer(Player player)
    // {
    //     m_player = player;
    //     m_weapon = m_player.GetComponentInChildren<Weapon>();
    // }
    // public void GetInfo(ElementInfo info)
    // {
    //     m_element.GetInfo(info.elementDB);
    //     //m_element.elementDB
    // }

    public override void Interact(Player player)
    {
        player.Pickup(m_element);
    }

    // void Update()
    // {
    //     // Проверяем, была ли нажата левая кнопка мыши
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // Создаем луч из камеры
    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit hit;

    //         // Проверяем, попал ли луч на объект PickupObject
    //         if (Physics.Raycast(ray, out hit))
    //         {
    //             if (hit.collider.gameObject == gameObject)
    //             {
    //                 Pickup();
    //             }
    //         }
    //     }
    // }
}
