using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

enum RoomType
{
    Boss,Enemy,Shop
}

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

    //GeneriqueRoom currentRoom;
    GameObject currentRoom;
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

    public void RoomExited(Directions dir)
    {
        Debug.Log(dir);
    }
    // // // 

    void GenerateRooms()
    {

    }

    void SetCurrentRoom(RoomType roomType)
    {
        //set room type path
        string roomPath = "Prefabs/Rooms/" + roomType.ToString() + "/";

        //now grab a room in this folder randomly

        string roomName = "enemy1";

        //then instantiate the room and store it into currentRoom
        currentRoom = Resources.Load<GameObject>(roomPath + roomName);
        

    }

}
