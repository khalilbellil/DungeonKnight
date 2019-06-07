using UnityEngine;

public class GameFlow : Flow
{
    private Player player;
    public override void Initialize(Player player)
    {
        this.player = player;

        initialized = true;
    }

    public override void Update(float dt)
    {

        InputManager.Instance.UpdateManager();
        PlayerManager.Instance.UpdateManager();

        Debug.Log("GAMEFLOW");
    }

    public override void FixedUpdate(float dt)
    {
        InputManager.Instance.FixedUpdateManager();
        PlayerManager.Instance.FixedUpdateManager();
    }

    public override void EndFlow()
    {

    }

}
