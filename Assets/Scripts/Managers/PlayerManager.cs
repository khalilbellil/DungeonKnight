﻿using UnityEngine;

public class PlayerManager
{
    #region Singleton Pattern
    private static PlayerManager instance = null;
    private PlayerManager() { }
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerManager();
            }
            return instance;
        }
    }
    #endregion

    public Player player;
    bool gameOverDone = false;

    public void Initialize()
    {
        SpawnPlayer();
        player.Init();



        //Debug.Log("PlayerManager Initialize");

    }

    public void UpdateManager(float dt)
    {
        //input.UpdateActions(InputManager.Instance.inputPressed.dirPressed, player);
        player.PlayerUpdate(InputManager.Instance.inputPressed, dt);
        if (!player.isAlive && !gameOverDone)
        {
                gameOverDone = true;
                GameOver();

        }
    }

    public void FixedUpdateManager(float dt)
    {
        //input.UpdatePosition(InputManager.Instance.inputPressed.dirPressed, player);
        player.PlayerFixedUpdate(InputManager.Instance.fixedInputPressed, dt);
		
    }

    public void StopManager()
    {//Reset everything
        instance = null;
    }


    void SpawnPlayer()
    {
        //Instantiate the Player(s)
        player = GameObject.Instantiate(Resources.Load<Player>(PrefabsDir.playerDir));
        //player.enabled = true;
    }

    void GameOver()
    {
        //Game Over UI Here (Call the UIManager function to activate the concerned UI)
        Debug.Log("Game Over !");

    }

}
