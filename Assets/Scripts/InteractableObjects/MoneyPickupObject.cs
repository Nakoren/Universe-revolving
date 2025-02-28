using System.Data.Common;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class MoneyPickupObject : PickUpObject
{
    public int money = 0;
    public void SetValue(int value)
    {
        money = value;
    }
    public override void Interact()
    {
        // onPickup?.Invoke(this);
        // //player.Pickup(m_part);
        // Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.PlusMoney(money);
        }
        // if(onDestroy != null)
        // {
        //     onDestroy.Invoke();
        // }
        Destroy(gameObject);
    }
}
