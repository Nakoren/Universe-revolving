using Unity.AppUI.UI;
using UnityEngine;

public class StandartChest : RewardContainer
{
    public PickupObject pickupObject;
    public override void Interact(Player player)
    {
        if (onOpen != null) onOpen.Invoke();
        int randItemIndex = Random.Range(0, rewardItemDB.items.Count);
        PickupDrop(rewardItemDB.items[randItemIndex].part);
        

        Destroy(this.gameObject);
    }
    public void PickupDrop(IPart part)
    {
        PickupObject m_pickup = Instantiate(pickupObject, transform.position, transform.rotation);
        m_pickup.GetPart(part);
    }
}
