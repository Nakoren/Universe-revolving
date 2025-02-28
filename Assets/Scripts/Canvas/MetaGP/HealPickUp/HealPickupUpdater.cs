using TMPro;
using UnityEngine;

public class HealPickupUpdater : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI DescriptionText;
    [SerializeField] protected string baseText1 = "Heals player by ";
    [SerializeField] protected string baseText2 = "HP";

    private HealPickUp m_healPickUp;

    private void Awake()
    {
        m_healPickUp = GetComponent<HealPickUp>();
        UpdateText();
    }

    public virtual void UpdateText()
    {
        int healValue = m_healPickUp.healValue;
        DescriptionText.text = $"{baseText1} {healValue.ToString()} {baseText2}";
    }
}
