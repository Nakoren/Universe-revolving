using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BattleRoomController : RoomController
{
    [SerializeField] List<List<GameObject>> enemyList;

    private bool instantCompletion = false;
    private int currentWave;

    private void Awake()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            for(int j = 0; j < enemyList[i].Count; j++)
            {
                
            }
        }
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemyList[currentWave].Remove(enemy.gameObject);
        if (enemyList[currentWave].Count == 0 ) {
            LoadNextWave();   
        }
    }

    private void LoadFirstWave()
    {
        currentWave = -1;
        LoadNextWave();
    }

    public void LoadNextWave()
    {
        if(currentWave >= enemyList.Count)
        {
            FinishRoomTask();
        }
        else
        {
            currentWave += 1;
        }
    }

   
}
