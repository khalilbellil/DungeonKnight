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
		/*for (int i = 0; i < enemiesAlive.Count; i++)
        {
            enemiesAlive[i].
        }*/
		//SpawnEnemy(1,new Vector2(41,12));
		//es.Init();

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

	void SpawnEnemy(int roomLvl, Vector2 location)
	{//Instantiate the Enemy(ies), add him to the collection, then add effects(sounds, ...)
		Enemy es = GameObject.Instantiate(Resources.Load<EnemySword>(PrefabsDir.enemyDir)).GetComponent<Enemy>();
		es.Init();
		AddEnemy(es);
	}

	void AddEnemy(Enemy enemyToAdd)
	{//add enemy to the collection
		enemiesAlive.Add(enemyToAdd);
	}

	public void RemoveEnemy(Enemy enemyToRemove)
	{//remove enemy from the collection
		enemiesAlive.Remove(enemyToRemove);
	}

}
