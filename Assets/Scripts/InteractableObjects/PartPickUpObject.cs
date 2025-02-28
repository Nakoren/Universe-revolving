using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static PartsDB;

public class PartPickUpObject : PickUpObject
{
    public Item item;
    private ItemInst m_roteting;

    public void Awake()
    {
        m_roteting = GetComponent<ItemInst>();
    }

    public void GetPart(Item item)
    {
        m_roteting = GetComponent<ItemInst>();
        this.item = item;
        m_roteting.GetPart(item);
    }
}
