using System;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] public Transform startPosition;

    [SerializeField] GameObject[] openTransitions;
    [SerializeField] GameObject[] closeTransitions;

    public Action<int> onRoomChange;

    private Room[] connectedRooms;
    private void Awake()
    {
        
    }

    public void Initialize(List<Room> connectedRoomsList)
    {
        for (int i = 0; i < connectedRoomsList.Count; ++i) {
            openTransitions[i].SetActive(true);
            Transitor curTransitor = openTransitions[i].GetComponent<Transitor>();
            curTransitor.Initiate(connectedRoomsList[i], i);
            curTransitor.onActivate += OnRoomChange;
        }
        for (int i = connectedRoomsList.Count; i < closeTransitions.Length; i++)
        {
            closeTransitions[i].SetActive(true);
        }
    }

    public void OnRoomChange(int ind)
    {
        onRoomChange.Invoke(ind);
    }
}
