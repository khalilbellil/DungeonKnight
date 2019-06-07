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

    ArrayList enemiesAlive = new ArrayList();

    // // // 

    public void Initialize()
    {

    }

    public void UpdateManager()
    {

    }

    public void FixedUpdateManager()
    {

    }

    public void StopManager()
    {

    }

    // // // 

    void SpawnEnemy(int roomLvl)
    {//Instantiate the Enemy(ies)

    }

    void AddEnemy(Enemy enemyToAdd)
    {//add enemy to the collection
        enemiesAlive.Add(enemyToAdd);
    }

    void RemoveEnemy(Enemy enemyToRemove)
    {//remove enemy from the collection
        enemiesAlive.Remove(enemyToRemove);
    }
}
