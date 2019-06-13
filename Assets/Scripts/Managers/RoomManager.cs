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
    
    //Room room;
    int[,,] roomsPositions = new int[10, 10, 10]; //Store all the rooms positions, Template: roomsPositions[i,x,y]; Example: roomsPositions[1,5,5]; -> room1(5,5)

    string[] prototypeRooms = new string[1];
    string[] enemiesRooms = new string[2];
    string[] bossRooms = new string[2];
    string[] shopRooms = new string[2];
    string[] spawnRooms = new string[2];

    GeneriqueRooms currentRoom; //The room where the player is.
    Directions dirPlayerCameFrom; //Direction the player came from (example: If he takes the North Door, in the next room he will be exiting the South Door)
    // // // 

    public void Initialize()
    {//Generate Rooms
        //room = GameObject.FindObjectOfType<Room>();
        //SetCurrentRoomRandomly(RoomType.Prototype);
        GenerateRooms();
        //Debug.Log("RoomManager.Initialize()");
    }

    public void UpdateManager()
    {

    }

    public void FixedUpdateManager()
    {
       // Debug.Log("RoomManager.FixedUpdateManager()");
    }

    public void StopManager()
    {
        Debug.Log("RoomManager.StopManager()");
        instance = null;
    }

    public void RoomExited(Directions dir)
    {//Get the direction of the last taken door (from the last room)
        if (dir == Directions.North)
        {
            dirPlayerCameFrom = Directions.South;
        }
        else if (dir == Directions.South)
        {
            dirPlayerCameFrom = Directions.North;
        }
        else if (dir == Directions.West)
        {
            dirPlayerCameFrom = Directions.East;
        }
        else if (dir == Directions.East)
        {
            dirPlayerCameFrom = Directions.West;
        }
        Debug.Log("RoomExited, you will came from: " + dirPlayerCameFrom + " for the next room");
    }
    // // // 

    void GenerateRooms()
    {
        //Room Generation Logic: -First room always has to be a SpawnRoom, -check every door(N,S,W,E) and generate a room in this direction after the actual room.

    }

    void SetCurrentRoomRandomly(RoomType roomType)
    {
        //set room type path
        string roomPath = "Prefabs/Room/" + roomType.ToString() + "/";

        //now grab a room in this folder randomly
        string roomName;
        int lenght = prototypeRooms.Length;

        switch (roomType)
        {
            case RoomType.Spawn:
                lenght = spawnRooms.Length;
                break;
            case RoomType.Enemy:
                lenght = enemiesRooms.Length;
                break;
            case RoomType.Boss:
                lenght = bossRooms.Length;
                break;
            case RoomType.Shop:
                lenght = shopRooms.Length;
                break;
            case RoomType.None:
                Debug.Log("RoomType is null");
                break;
            default:
                break;
        }
        
        int rand = Random.Range(0, lenght);
        roomName = prototypeRooms[rand];

        roomPath += roomName;

        //then instantiate the room and store it into currentRoom
        //room.SetRoom(roomPath);
    }

    public RoomType RoomTypeOfDir(Directions dir)
    {
        RoomType retour = RoomType.None;
        //check roomtype of the 4 neighbors (N, S, W, E)
        //return the roomType of the wanted dir

        return retour;
    }

}
