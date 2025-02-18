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
        m_roteting.GetPart(part.model);
    }

    public override void Interact(Player player)
    {
        player.Pickup(m_part);
        Destroy(gameObject);
    }
}
