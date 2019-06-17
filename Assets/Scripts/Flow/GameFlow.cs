using UnityEngine;

public class GameFlow : Flow
{
    MainEntry mainEntry;

    public override void Initialize()
    {
        mainEntry = GameObject.FindObjectOfType<MainEntry>();

        InputManager.Instance.Initialize();
        UIManager.Instance.Initialize();
        PlayerManager.Instance.Initialize();
        RoomManager.Instance.Initialize();
        EnemyManager.Instance.Initialize();
        initialized = true;
    }

    public override void Update(float dt)
    {
        InputManager.Instance.UpdateManager();
        UIManager.Instance.UpdateManager();
        PlayerManager.Instance.UpdateManager(dt);
        RoomManager.Instance.UpdateManager();
        EnemyManager.Instance.UpdateManager();
    }

    public override void FixedUpdate(float dt)
    {
        InputManager.Instance.FixedUpdateManager();
        UIManager.Instance.FixedUpdateManager();
        PlayerManager.Instance.FixedUpdateManager(dt);
        RoomManager.Instance.FixedUpdateManager();
        EnemyManager.Instance.FixedUpdateManager();
    }

    public override void EndFlow()
    {
        InputManager.Instance.StopManager();
        UIManager.Instance.StopManager();
        PlayerManager.Instance.StopManager();
        RoomManager.Instance.StopManager();
        EnemyManager.Instance.StopManager();
    }

}
