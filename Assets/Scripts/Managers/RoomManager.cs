using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    Room room;
    string[] prototypeRooms = new string[1];
    // // // 

    public void Initialize()
    {//Generate Rooms
        room = GameObject.FindObjectOfType<Room>();
        //SetCurrentRoomRandomly(RoomType.Prototype);
        Debug.Log("test");
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

    void SetCurrentRoomRandomly(RoomType roomType)
    {
        //set room type path
        string roomPath = "Prefabs/Room/" + roomType.ToString() + "/";

        //now grab a room in this folder randomly
        string roomName;
        int rand = Random.Range(0, prototypeRooms.Length);
        roomName = prototypeRooms[rand];

        roomPath += roomName;

        //then instantiate the room and store it into currentRoom
        room.SetRoom(roomPath);
    }

}
