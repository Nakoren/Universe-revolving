using UnityEngine;

public class HealPickUp : PickUpObject
{
    [SerializeField] public int healValue = 10;

    public void UpdateData()
    {
        HealPickupUpdater pickUpUpdater = GetComponent<HealPickupUpdater>();
        if(pickUpUpdater != null)
        {
            pickUpUpdater.UpdateText();
        }
    }
}
