using System;
using UnityEngine;

public class RewardContainer : MonoBehaviour
{
    [SerializeField] GameObject rewardItem;
    public Action onOpen;

    public void Open()
    {
        if(onOpen != null) onOpen.Invoke();

        //Расширить механизм спавна дропа с сундука
        Instantiate(rewardItem, this.transform);

        Destroy(this.gameObject);
    }
}
