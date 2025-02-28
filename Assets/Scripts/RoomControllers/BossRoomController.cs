using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;

public class BossRoomController : RoomController
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
    [SerializeField] Enemy boss;

    private List<Enemy> addedEnemies = new List<Enemy>();
    private int currentWave;
    

    override protected void SpecProcessing()
    {
        if (boss == null)
        {
            instantCompletion = true;
            FinishRoomTask();
        }
        else
        {
            instantCompletion = false;
            StartBossFight();
        }
        
    }

    private void OnDestroy()
    {
        foreach (Enemy sum in addedEnemies)
        {
            Destroy(sum.gameObject);
        }
    }

    private void OnEnemyDeath(Enemy enemy)
    {
        if(enemy == boss)
        {
            foreach(Enemy sum in addedEnemies)
            {
                sum.Die();
                sum.onEnemyDeath -= OnEnemyDeath;
            }
            FinishRoomTask();
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

    public void StartBossFight()
    {
        boss.onEnemyDeath += OnEnemyDeath;
        boss.SetTarget(player.transform);
        boss.Activate();
    }

    public void AddEnemy(Enemy enemy)
    {
        addedEnemies.Add(enemy);
    }
}
