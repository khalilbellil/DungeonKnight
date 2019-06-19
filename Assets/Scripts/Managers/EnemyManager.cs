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


    public List<Enemy> enemiesAlive = new List<Enemy>();
    ArrayList coins = new ArrayList();
    //public EnemySword es;

    // // // 

    public void Initialize()
    {
        
        SpawnEnemy(1,new Vector2(41,12));
        
    }

    public void UpdateManager(float dt)
    {//Check if enemies are alive, if not call KillEnemy.
        foreach (Enemy es in enemiesAlive)
            es.UnitUpdate(dt);

    }

    public void FixedUpdateManager(float dt)
    {
        foreach (Enemy es in enemiesAlive)
            es.UnitFixedUpdate();
    }

    public void StopManager()
    {
        instance = null;
    }

    // // // 

    void SpawnEnemy(int roomLvl,Vector2 location)
    {//Instantiate the Enemy(ies), add him to the collection, then add effects(sounds, ...)
        Enemy es = GameObject.Instantiate(Resources.Load<EnemySword>(PrefabsDir.enemyDir)).GetComponent<Enemy>();
        es.Init();
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
