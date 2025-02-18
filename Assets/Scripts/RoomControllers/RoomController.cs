
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] public Transform startPosition;

    [SerializeField] protected Transitor[] activeTransitions;
    [SerializeField] protected GameObject[] closeTransitions;

    [SerializeField] protected List<RoomReward> possibleRewards;

    public Action<int> onRoomChange;
    public Action onFinalRoomChange;
    private int connectionsCount;
    protected Player player;
    protected bool instantCompletion = true;

    private Icons icons;

    public Player Player { get { return player; } set { { player = value; } } }

    private Room[] connectedRooms;

    public void Initialize(List<Room> connectedRoomsList, Player player, Icons levelIcons)
    {
        this.icons = levelIcons;
        this.player = player;
        connectionsCount = connectedRoomsList.Count;
        if (connectedRoomsList.Count > 0)
        {
            for (int i = 0; i < connectionsCount; ++i)
            {
                closeTransitions[i].SetActive(false);
                Transitor currentTransitor = activeTransitions[i].GetComponent<Transitor>();
                activeTransitions[i] = currentTransitor;
                activeTransitions[i].gameObject.SetActive(true);
                activeTransitions[i].Initiate(connectedRoomsList[i], i, icons);
                activeTransitions[i].onActivate += OnRoomChange;
            }
            for (int i = connectionsCount; i < closeTransitions.Length; i++)
            {
                activeTransitions[i].gameObject.SetActive(false);
                closeTransitions[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < activeTransitions.Length; ++i)
            {
                Transitor currentTransitor = activeTransitions[i].GetComponent<Transitor>();
                activeTransitions[i] = currentTransitor;
                activeTransitions[i].gameObject.SetActive(true);
                activeTransitions[i].FinalInitiate(icons);
                activeTransitions[i].onFinalActivate += OnFinalRoomChange;
            }
        }
        this.SpecProcessing();   
    }

    virtual protected void SpecProcessing()
    {
        if (instantCompletion)
        {
            FinishRoomTask();
        }
    }

    protected virtual void FinishRoomTask()
    {
        for (int i = 0; i < connectionsCount; ++i)
        {
            //Тут нужно сделать более сложную логику открытия и закрытию проходов
            activeTransitions[i].Enable();
        }

        if(possibleRewards.Count > 0)
        {
            RoomReward reward = possibleRewards[UnityEngine.Random.Range(0, possibleRewards.Count)];
            //Реализовать тут механизм награды игрока
        }
    }

    protected void OnRoomChange(int ind)
    {
        onRoomChange.Invoke(ind);
    }
    protected void OnFinalRoomChange()
    {
        onFinalRoomChange.Invoke();
    }
}
