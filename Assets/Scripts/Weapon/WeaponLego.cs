using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponLego : MonoBehaviour
{
    private Weapon m_weapon;
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
        EmptyFix();
    }
    public void EmptyFix()
    {
        if (scope == null) scope = base_scope;
        if (magazine == null) magazine = base_magazine;
        if (receiver == null) receiver = base_receiver;
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
        if (part.type == 111)
        {
            Drop(scope);
            scope = (Scope)part;
        }
        else if (part.type == 222)
        {
            Drop(magazine);
            magazine = (Magazine)part;
        }
        else if (part.type == 333)
        {
            Drop(receiver);
            receiver = (Receiver)part;
        }
        else
        {
            Drop(part);
        }
    }
}
