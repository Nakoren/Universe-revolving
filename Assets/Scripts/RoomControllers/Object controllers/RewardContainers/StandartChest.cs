using UnityEngine;

public class StandartChest : RewardContainer
{
    public override void Interact(Player player)
    {
        if (onOpen != null) onOpen.Invoke();

        //��������� �������� ������ ����� � �������
        int randItemIndex = Random.Range(0, rewardItem.Count);
        Instantiate(rewardItem[randItemIndex], this.transform);

        Destroy(this.gameObject);
    }
}
