using UnityEngine;

public class RewardRoomController : RoomController
{
    [SerializeField] RewardContainer reward;

    override protected void SpecProcessing()
    {
        if (reward != null)
        {
            reward.onOpen += OnContainerOpen;
        }
        else
        {
            FinishRoomTask();
        }
    }

    public void OnContainerOpen()
    {
        FinishRoomTask();
    }
}
