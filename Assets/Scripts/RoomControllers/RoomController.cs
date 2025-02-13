
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] public Transform startPosition;

    [SerializeField] Transitor[] activeTransitions;
    [SerializeField] GameObject[] closeTransitions;

    [SerializeField] List<RoomReward> possibleRewards;

    

    public Action<int> onRoomChange;
    private int connectionsCount;
    protected Player player;
    protected bool instantCompletion = true;

    public Player Player { get { return player; } set { { player = value; } } }

    private Room[] connectedRooms;
    private void Awake()
    {
        
    }

    public void Initialize(List<Room> connectedRoomsList, Player player)
    {
        this.player = player;
        connectionsCount = connectedRoomsList.Count;
        for (int i = 0; i < connectionsCount; ++i) {
            Transitor curTransitor = activeTransitions[i].GetComponent<Transitor>();
            curTransitor.Initiate(connectedRoomsList[i], i);
            curTransitor.onActivate += OnRoomChange;
            curTransitor.gameObject.SetActive(true);
        }
        for (int i = connectionsCount; i < closeTransitions.Length; i++)
        {
            closeTransitions[i].SetActive(true);
        }
        SpecProcessing();   
    }

    virtual protected void SpecProcessing()
    {
        if (instantCompletion)
        {
            FinishRoomTask();
        }
    }

    protected void FinishRoomTask()
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
}
