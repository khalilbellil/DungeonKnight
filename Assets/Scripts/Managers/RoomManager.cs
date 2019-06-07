using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager
{
    #region Singleton Pattern
    private static RoomManager instance = null;
    private RoomManager() { }
    public static RoomManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new RoomManager();
            }
            return instance;
        }
    }
    #endregion

    // // // 

    public void Initialize()
    {//Generate Rooms
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

}
