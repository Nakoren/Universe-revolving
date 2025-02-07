using UnityEngine;

public class StandartChest : RewardContainer
{
    public override void Open()
    {
        if (onOpen != null) onOpen.Invoke();

        //��������� �������� ������ ����� � �������
        Instantiate(rewardItem, this.transform);


        Destroy(this.gameObject);
    }
}
