using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;

public class BattleRoomController : RoomController
{
    /*
    [System.Serializable]
    public class SubList
    {
        public List<Enemy> waveEnemies = new List<Enemy>();
    }

    // использование
    public List<SubList> enemies = new List<SubList>();
    private List<List<Enemy>> enemyList;
    */

    [SerializeField] private List<Wave> waves;

    private int currentWave;
    

    override protected void SpecProcessing()
    {
        if (waves.Count == 0)
        {
            instantCompletion = true;
            FinishRoomTask();
        }
        else
        {
            instantCompletion = false;
            LoadWave(0);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < waves.Count; i++)
        {
            Wave curWave = waves[i];
            for (int j = 0; j < curWave.enemiesList.Count; j++)
            {
                curWave.enemiesList[j].onEnemyDeath -= OnEnemyDeath;
            }
        }
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        waves[currentWave].enemiesList.Remove(enemy);   
        if (waves[currentWave].enemiesList.Count == 0 ) {
            currentWave++;
            LoadWave(currentWave);
        }
    }

    protected void LoadWave(int wave)
    {
        if(currentWave >= waves.Count)
        {
            FinishRoomTask();
        }
        else
        {
            waves[wave].InitWave(player, OnEnemyDeath);
        }
    }

    override protected void FinishRoomTask()
    {
        for (int i = 0; i < activeTransitions.Length; ++i)
        {
            //Тут нужно сделать более сложную логику открытия и закрытию проходов
            activeTransitions[i].Enable();
        }
        if (rewardContainer != null)
        {
            Instantiate(rewardContainer, rewardSpawnPosition);
        }
    }

    public virtual void AddEnemy(Enemy enemy)
    {
        waves[currentWave].Add(enemy);
    }
}
