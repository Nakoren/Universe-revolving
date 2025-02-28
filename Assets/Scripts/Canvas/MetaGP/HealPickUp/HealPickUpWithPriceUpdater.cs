using TMPro;
using UnityEngine;

public class HealPickUpWithPriceUpdater : HealPickupUpdater
{
    [SerializeField] TextMeshProUGUI priceText;
    [SerializeField] string basePriceText1 = "Price:";

    HealPickUpWithPrice m_healPickUpWithPrice;

    private void Awake()
    {
        m_healPickUpWithPrice = GetComponent<HealPickUpWithPrice>();
        UpdateText();
    }

    public override void UpdateText()
    {
        
        int healValue = m_healPickUpWithPrice.healValue;
        DescriptionText.text = $"{baseText1} {healValue.ToString()} {baseText2}";

        int cost = m_healPickUpWithPrice.Price;
        priceText.text = $"{basePriceText1} \n {cost.ToString()}";
    }
}
