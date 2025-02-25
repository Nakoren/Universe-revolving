using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupObject : IInteractable
{
    public IPart m_part;
    private RotetingObgect m_roteting;

    public void Awake()
    {
        m_roteting = GetComponent<RotetingObgect>();
    }

    public void GetPart(IPart part)
    {
        m_roteting = GetComponent<RotetingObgect>();
        m_part = part;
        m_roteting.GetPart(part);
    }

    public override void Interact()
    {
        onPickup?.Invoke(m_part);
        //player.Pickup(m_part);
        Destroy(gameObject);
    }
}
