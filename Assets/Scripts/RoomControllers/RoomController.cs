
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
            curTransitor.gameObject.SetActive(true);
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
            //��� ����� ������� ����� ������� ������ �������� � �������� ��������
            activeTransitions[i].Enable();
        }

        if(possibleRewards.Count > 0)
        {
            RoomReward reward = possibleRewards[UnityEngine.Random.Range(0, possibleRewards.Count)];
            //����������� ��� �������� ������� ������
        }
    }

    protected void OnRoomChange(int ind)
    {
        onRoomChange.Invoke(ind);
    }
}
