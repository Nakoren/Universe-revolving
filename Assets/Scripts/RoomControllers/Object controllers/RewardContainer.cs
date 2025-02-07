using System;
using UnityEngine;

public abstract class RewardContainer : MonoBehaviour
{
    [SerializeField] protected GameObject rewardItem;
    public Action onOpen;

    abstract public void Open();
}
