using System;
using UnityEngine;

public class PartPickUpWithPrice : PartPickUpObject, IItemWithPrice
{
    [SerializeField] int price;
    public int Price {  get { return price; } set { Math.Max(price, value); } }

    public void SetPrice()
    {
        PickupInformation_Table infoTable = GetComponent<PickupInformation_Table>();
        infoTable.SetPrice(price);
    }
}
