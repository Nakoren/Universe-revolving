using Unity.AppUI.UI;
using UnityEngine;
using static PartsDB;

public class StandartChest : RewardContainer
{
    public PartPickUpObject pickupObject;
    public override void Interact()
    {
        if (onOpen != null) onOpen.Invoke();
        int randItemIndex = Random.Range(0, rewardItemDB.items.Count);
        PickupDrop(rewardItemDB.items[randItemIndex]);
        Destroy(this.gameObject);
    }
    public void PickupDrop(Item item)
    {
        //What the actual fuck is this shit
        PartPickUpObject m_pickup = Instantiate(pickupObject, transform.position, transform.rotation);
        m_pickup.GetPart(item);
    }
}
