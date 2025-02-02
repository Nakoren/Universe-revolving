using System;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] public Transform startPosition;

    [SerializeField] GameObject[] activeTransitions;
    [SerializeField] GameObject[] inActiveTransitions;
    [SerializeField] GameObject[] closeTransitions;

    public Action<int> onRoomChange;
    private int connectionsCount;
    private bool instantCompletion = true;

    private Room[] connectedRooms;
    private void Awake()
    {
        
    }

    public void Initialize(List<Room> connectedRoomsList)
    {
        connectionsCount = connectedRoomsList.Count;
        for (int i = 0; i < connectionsCount; ++i) {
            Transitor curTransitor = activeTransitions[i].GetComponent<Transitor>();
            curTransitor.Initiate(connectedRoomsList[i], i);
            curTransitor.onActivate += OnRoomChange;

            inActiveTransitions[i].SetActive(true);
        }
        for (int i = connectionsCount; i < closeTransitions.Length; i++)
        {
            closeTransitions[i].SetActive(true);
        }
        if(instantCompletion)
        {
            FinishRoomTask();
        }
    }

    protected void FinishRoomTask()
    {
        for (int i = 0; i < connectionsCount; ++i)
        {
            activeTransitions[i].SetActive(false);
            inActiveTransitions[i].SetActive(true);
        }
    }

    protected void OnRoomChange(int ind)
    {
        onRoomChange.Invoke(ind);
    }
}
