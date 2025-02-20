using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponLego : MonoBehaviour
{
    private Weapon m_weapon;
    private WeaponVisual m_visual;
    public PickupObject pickupPrefab;
    public float totalDamage;

    [Header("Base Parts")]
    public Scope base_scope;
    public Magazine base_magazine;
    public Receiver base_receiver;

    [Header("Current Parts")]
    public Scope scope;
    public Magazine magazine;
    public Receiver receiver;
    

    public void Awake()
    {
        m_weapon = GetComponent<Weapon>(); 
        m_visual = GetComponent<WeaponVisual>(); 
        EmptyFix();
    }
    public void EmptyFix()
    {
        if (scope == null) 
        {
            scope = base_scope;
            m_visual?.SetElementScope(base_scope);
        }
        if (magazine == null) 
        {
            magazine = base_magazine;
            m_visual?.SetElementMagazine(base_magazine);
        }
        if (receiver == null) 
        {
            receiver = base_receiver;
            m_visual?.SetElementReceiver(base_receiver);
        }
    }
    public void GoBase()
    {
        scope = base_scope;
        magazine = base_magazine;
        receiver = base_receiver;
    }
    public void GetElements()
    {
        totalDamage = 20 * scope.damageRate * magazine.damageRate * receiver.damageRate;
    }
    public void Drop(IPart part)
    {
        PickupObject pickup = Instantiate(pickupPrefab, this.transform.position, this.transform.rotation);
        pickup.GetPart(part);
    }

    public void Pickup(IPart part) 
    {  

        if (part.type == IPart.Ptype.Scope)
        {
            Drop(scope);
            scope = (Scope)part;
            m_visual?.SetElementScope(part);
        }
        else if (part.type == IPart.Ptype.Magazine)
        {
            Drop(magazine);
            magazine = (Magazine)part;
            m_visual?.SetElementMagazine(part);
        }
        else if (part.type == IPart.Ptype.Receiver)
        {
            Drop(receiver);
            receiver = (Receiver)part;
            m_visual?.SetElementReceiver(part);
        }
        else
        {
            Drop(part);
        }
    }
}
