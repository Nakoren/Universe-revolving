using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BattleRoomController : RoomController
{
    [SerializeField] List<List<Enemy>> enemyList;
    private int currentWave;

    private void Awake()
    {
        instantCompletion = false;
        for (int i = 0; i < enemyList.Count; i++)
        {
            for(int j = 0; j < enemyList[i].Count; j++)
            {
                enemyList[i][j].onEnemyDeath += OnEnemyDeath;
            }
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            for (int j = 0; j < enemyList[i].Count; j++)
            {
                enemyList[i][j].onEnemyDeath -= OnEnemyDeath;
            }
        }
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        enemyList[currentWave].Remove(enemy);
        if (enemyList[currentWave].Count == 0 ) {
            currentWave++;
            LoadWave(currentWave);   
        }
    }

    public void LoadWave(int wave)
    {
        if(currentWave >= enemyList.Count)
        {
            FinishRoomTask();
        }
        else
        {
            for( int i = 0;i < enemyList[wave].Count; i++)
            {
                enemyList[wave][i].Activate();
            }
        }
    }

    public void AddEnemy(Enemy enemy)
    {
        enemyList[currentWave].Add(enemy);
    }
}
