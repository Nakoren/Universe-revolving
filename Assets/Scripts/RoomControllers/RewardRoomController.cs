using UnityEngine;

public class RewardRoomController : RoomController
{
    [SerializeField] RewardContainer rewardContainer;

    public void OnContainerOpen()
    {
        FinishRoomTask();
    }
}
