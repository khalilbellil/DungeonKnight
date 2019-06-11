﻿using UnityEngine;

public class PlayerManager
{
    private InputController input;
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
        //input = InputController.Instance;
        //input.Initialize(player);
        Debug.Log("PlayerManager Initialize");
    }

    public void UpdateManager()
    {
        //input.UpdateActions(InputManager.Instance.inputPressed.dirPressed, player);
        player.PlayerUpdate(InputManager.Instance.inputPressed);

        if (!player.isAlive && !gameOverDone)
        {
            gameOverDone = true;
            GameOver();
        }

    }

    public void FixedUpdateManager()
    {
        //input.UpdatePosition(InputManager.Instance.inputPressed.dirPressed, player);
        player.PlayerFixedUpdate(InputManager.Instance.fixedInputPressed);
		
    }

    public void StopManager()
    {

    }


    void SpawnPlayer()
    {
        //Instantiate the Player(s)
        player = GameObject.Instantiate(Resources.Load<Player>(PrefabsDir.playerDir));
    }

    void GameOver()
    {
        //Game Over UI Here
        Debug.Log("Game Over !");
    }

}
