using UnityEngine;

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

    private Player player;



    public void Initialize(Player player)
    {
        this.player = player;
        SpawnPlayer();
        input = InputController.Instance;
        input.Initialize(player);
    }

    public void UpdateManager()
    {
        input.UpdateActions(InputManager.Instance.inputPressed.dirPressed, player);
        player.UnitUpdate(InputManager.Instance);
    }

    public void FixedUpdateManager()
    {
        input.UpdatePosition(InputManager.Instance.inputPressed.dirPressed, player);
    }

    public void StopManager()
    {

    }

    //Functions:

    void SpawnPlayer()
    {

    }

}
