using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PartsDB;

public class PickupObject : IInteractable
{
    public Item m_item;
    private ItemInst m_roteting;

    public void Awake()
    {
        m_roteting = GetComponent<ItemInst>();
    }

    public void GetPart(Item item)
    {
        m_roteting = GetComponent<ItemInst>();
        m_item = item;
        m_roteting.GetPart(item);
    }

    public override void Interact()
    {
        onPickup?.Invoke(m_item);
        //player.Pickup(m_part);
        Destroy(gameObject);
    }
}
