using System;
using System.Collections.Generic;
using UnityEngine;

public class GivePlayer : MonoBehaviour
{
    public Player player;
    private List<PartPickUpObject> m_pickup = new List<PartPickUpObject>();

    public void Awake()
    {
        m_pickup.AddRange(GetComponentsInChildren<PartPickUpObject>());
        //GetPlayer();
    }

    // private void GetPlayer()
    // {
    //     for ( int i = 0; i < m_pickup.Count; i++ )
    //     {
    //         m_pickup[i].GetPlayer(player);
    //     }
    // }
}
