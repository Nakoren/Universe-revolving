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
                enemyList[wave][i].SetActive(true);
            }
        }
    }

    public void addEnemy(Enemy enemy)
    {
        enemyList[currentWave].Add(enemy.gameObject);
    }
}
