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

    // // //

    public void Initialize()
    {
        SpawnPlayer();
    }

    public void UpdateManager()
    {

    }

    public void FixedUpdateManager()
    {
    }

    public void StopManager()
    {

    }

    // // //

    //Functions:

    void SpawnPlayer()
    {//Instantiate the Player(s)
        
    }

}
