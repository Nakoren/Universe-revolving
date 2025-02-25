using UnityEngine;

public class RewardRoomController : RoomController
{
    [SerializeField] RewardContainer reward;

    override protected void SpecProcessing()
    {
        reward.onOpen += OnContainerOpen;
    }

    public void OnContainerOpen()
    {
        FinishRoomTask();
    }
}
