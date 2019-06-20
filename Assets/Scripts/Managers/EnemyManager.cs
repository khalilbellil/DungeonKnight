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

    // // // 

    public void Initialize()
    {

    }

    public void UpdateManager(float dt)
    {//Check if enemies are alive, if not call KillEnemy.
        foreach (Enemy es in enemiesAlive)
            es.UnitUpdate(dt, (PlayerManager.Instance.player.transform.position - es.transform.position).normalized);
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

    public void SpawnEnemy(int roomLvl,Vector2 location)
    {//Instantiate the Enemy(ies), add him to the collection, then add effects(sounds, ...)
        Enemy es = GameObject.Instantiate(Resources.Load<EnemySword>(PrefabsDir.enemyDir)).GetComponent<Enemy>();
        Enemy eb = GameObject.Instantiate(Resources.Load<EnemyBow>(PrefabsDir.enemyBDir)).GetComponent<Enemy>();
        es.Init();
        eb.Init();
        AddEnemy(es);
        AddEnemy(eb);
    }

	public void SpawnBoss(Vector2 location)
	{
		Boss boss = GameObject.Instantiate(Resources.Load<Boss>(PrefabsDir.enemyDir)).GetComponent<Boss>();
		boss.transform.position = location;
		boss.Init();
		AddEnemy(boss);
	}

	void AddEnemy(Enemy enemyToAdd)
    {//add enemy to the collection
        enemiesAlive.Add(enemyToAdd);
    }

    public void RemoveEnemy(Enemy enemyToRemove)
    {//remove enemy from the collection
        enemiesAlive.Remove(enemyToRemove);
    }

    void SpawnCoin(Vector2 killedEnemyPosition)
    {//Instantiate the Coin and set his position to the killed enemy position, then add it to the collection

    }
}
