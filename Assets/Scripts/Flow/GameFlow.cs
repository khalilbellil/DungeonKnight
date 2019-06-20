using UnityEngine;

public class GameFlow : Flow
{
    MainEntry mainEntry;

    public static bool isGame;

    public override void Initialize()
    {
        mainEntry = GameObject.FindObjectOfType<MainEntry>();

        InputManager.Instance.Initialize();
        UIManager.Instance.Initialize();
        PlayerManager.Instance.Initialize(this);
        RoomManager.Instance.Initialize();
        EnemyManager.Instance.Initialize();
        ProjectileManager.Instance.Initialize();
        initialized = true;
        isGame = true;
    }

    public override void Update(float dt)
    {
        UIManager.Instance.UpdateManager();
        if (isGame)
        {
            InputManager.Instance.UpdateManager();
            PlayerManager.Instance.UpdateManager(dt);
            RoomManager.Instance.UpdateManager();
            EnemyManager.Instance.UpdateManager(dt);
            ProjectileManager.Instance.UpdateManager(dt);
        }
        
    }

    public override void FixedUpdate(float dt)
    {
        UIManager.Instance.FixedUpdateManager();
        if (isGame)
        {
            InputManager.Instance.FixedUpdateManager();
            PlayerManager.Instance.FixedUpdateManager(dt);
            RoomManager.Instance.FixedUpdateManager();
            EnemyManager.Instance.FixedUpdateManager(dt);
            ProjectileManager.Instance.FixedUpdateManager(dt);
        }
        
    }

    public override void EndFlow()
    {
        ProjectileManager.Instance.StopManager();
        InputManager.Instance.StopManager();
        UIManager.Instance.StopManager();
        PlayerManager.Instance.StopManager();
        RoomManager.Instance.StopManager();
        EnemyManager.Instance.StopManager();

    }


	public void PlayerDied() {
		isGame = false;
		UIManager.Instance.CallDeathScreen();
	}
}
