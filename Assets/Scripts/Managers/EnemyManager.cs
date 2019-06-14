using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{
    #region Singleton Pattern
    private static EnemyManager instance = null;
    private EnemyManager() { }
    public static EnemyManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EnemyManager();
            }
            return instance;
        }
    }
    #endregion


    public ArrayList enemiesAlive = new ArrayList();
    ArrayList coins = new ArrayList();
    public EnemySword es;

    // // // 

    public void Initialize()
    {
        /*for (int i = 0; i < enemiesAlive.Count; i++)
        {
            enemiesAlive[i].
        }*/
        SpawnEnemy(1);
        es.Init();
        
    }

    public void UpdateManager()
    {//Check if enemies are alive, if not call KillEnemy.
        es.UnitUpdate();

    }

    public void FixedUpdateManager()
    {
        es.UnitFixedUpdate();
    }

    public void StopManager()
    {
        instance = null;
    }

    // // // 

    void SpawnEnemy(int roomLvl)
    {//Instantiate the Enemy(ies), add him to the collection, then add effects(sounds, ...)
        es = GameObject.Instantiate(Resources.Load<EnemySword>(PrefabsDir.enemyDir));
        AddEnemy(es);
    }

    void KillEnemy(Enemy killedEnemy)
    {//Remove the enemy from the collection, then add effects(spawn coin at his last position, sounds, update the player score)
        SpawnCoin(killedEnemy.transform.position);
        RemoveEnemy(killedEnemy);
    }

    void AddEnemy(Enemy enemyToAdd)
    {//add enemy to the collection
        enemiesAlive.Add(enemyToAdd);
    }

    void RemoveEnemy(Enemy enemyToRemove)
    {//remove enemy from the collection
        enemiesAlive.Remove(enemyToRemove);
    }

    void SpawnCoin(Vector2 killedEnemyPosition)
    {//Instantiate the Coin and set his position to the killed enemy position, then add it to the collection

    }
}
