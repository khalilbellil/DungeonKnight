using UnityEngine;

public class GameFlow : Flow
{
    private Player player;
    public override void Initialize(Player player)
    {
        this.player = player;
        InputManager.Instance.Initialize();
        UIManager.Instance.Initialize();
        RoomManager.Instance.Initialize();
        PlayerManager.Instance.Initialize(player);
        EnemyManager.Instance.Initialize();

        initialized = true;
    }

    public override void Update(float dt)
    {
        InputManager.Instance.UpdateManager();
        UIManager.Instance.UpdateManager();
        RoomManager.Instance.UpdateManager();
        PlayerManager.Instance.UpdateManager();
        EnemyManager.Instance.UpdateManager();
        
        Debug.Log("GAMEFLOW");
    }

    public override void FixedUpdate(float dt)
    {
        InputManager.Instance.FixedUpdateManager();
        UIManager.Instance.FixedUpdateManager();
        RoomManager.Instance.FixedUpdateManager();
        PlayerManager.Instance.FixedUpdateManager();
        EnemyManager.Instance.FixedUpdateManager();
    }

    public override void EndFlow()
    {
        InputManager.Instance.StopManager();
        UIManager.Instance.StopManager();
        RoomManager.Instance.StopManager();
        PlayerManager.Instance.StopManager();
        EnemyManager.Instance.StopManager();
    }

}
