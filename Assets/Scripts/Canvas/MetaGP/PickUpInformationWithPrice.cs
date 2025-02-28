using TMPro;
using UnityEngine;

public class PickUpInformationWithPrice : PickupInformation_Table
{
    [SerializeField] TextMeshProUGUI price_text;

    public void SetPrice(int price)
    {
        string priceString = $"Price: \n{price.ToString()}";
        price_text.text = priceString;
    }
}
