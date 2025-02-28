using System;
using System.Diagnostics;
using UnityEngine;

public class HealPickUpWithPrice : HealPickUp, IItemWithPrice
{
    [SerializeField] int price;
    public int Price { get { return price; } set { price = Math.Max(price, value); } }

    public override void UpdateData()
    {
        HealPickUpWithPriceUpdater pickUpUpdater = GetComponent<HealPickUpWithPriceUpdater>();
        if (pickUpUpdater != null)
        {
            pickUpUpdater.UpdateText();
            
        }
    }

}
