using UnityEngine;

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


    public void Initialize(Player player)
    {
        this.player = player;
        player.Init();
        SpawnPlayer();


    }

    public void UpdateManager()
    {
        //input.UpdateActions(InputManager.Instance.inputPressed.dirPressed, player);
        player.PlayerUpdate(InputManager.Instance.inputPressed);
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
        
    }

}
