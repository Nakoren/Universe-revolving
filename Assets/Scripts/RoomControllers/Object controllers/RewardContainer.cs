using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class RewardContainer : IInteractable
{
    [SerializeField] protected List<GameObject> rewardItem;
    public Action onOpen;

    
}
