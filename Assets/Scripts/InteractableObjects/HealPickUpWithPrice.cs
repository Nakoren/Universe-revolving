using System;
using System.Diagnostics;
using UnityEngine;

public class HealPickUpWithPrice : HealPickUp, IItemWithPrice
{

    [SerializeField] int price;
    public int Price { get { return price; } set { Math.Max(price, value); } }
}
