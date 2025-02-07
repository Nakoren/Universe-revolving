using UnityEngine;

public class StandartChest : RewardContainer
{
    public override void Interact()
    {
        if (onOpen != null) onOpen.Invoke();

        //Расширить механизм спавна дропа с сундука
        int randItemIndex = Random.Range(0, rewardItem.Count);
        Instantiate(rewardItem[randItemIndex], this.transform);

        Destroy(this.gameObject);
    }
}
