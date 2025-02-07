using UnityEngine;

public class StandartChest : RewardContainer
{
    public override void Open()
    {
        if (onOpen != null) onOpen.Invoke();

        //Расширить механизм спавна дропа с сундука
        Instantiate(rewardItem, this.transform);


        Destroy(this.gameObject);
    }
}
