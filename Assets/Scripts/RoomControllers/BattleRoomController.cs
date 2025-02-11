using NUnit.Framework;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

public class BattleRoomController : RoomController
{
    [System.Serializable]
    public class SubList
    {
        public List<Enemy> waveEnemies = new List<Enemy>();
    }

    // использование
    public List<SubList> enemies = new List<SubList>();

    private List<List<Enemy>> enemyList;
    private int currentWave;

    private void Awake()
    {
        enemyList = new List<List<Enemy>>();
        for (int i = 0; i < enemies.Count; i++)
        {
            enemyList.Add(new List<Enemy>());
            for (int j = 0; j < enemies[i].waveEnemies.Count; j++)
            {
                enemyList[i].Add(enemies[i].waveEnemies[j]);
            }
        }
        if (enemyList.Count == 0)
        {
            instantCompletion = true;
        }
        else
        {
            instantCompletion = false;

            for (int i = 0; i < enemyList.Count; i++)
            {
                for (int j = 0; j < enemyList[i].Count; j++)
                {
                    enemyList[i][j].onEnemyDeath += OnEnemyDeath;
                }
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
