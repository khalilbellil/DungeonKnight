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

    public RoomType[,] rooms = new RoomType[10,10]; //The RoomTypes will be generated "randomly"

    public GameObject currentRoom; //The room where the player is.
    public Vector2Int currentRoomPos;
    Directions dirPlayerCameFrom; //Direction the player came from (example: If he takes the North Door, in the next room he will be exiting the South Door)
    
    // // // 

    public void Initialize()
    {//Generate Rooms
        currentRoom = GameObject.FindObjectOfType<GeneriqueRooms>().gameObject;

        SetCurrentRoomRandomly(RoomType.Spawn);
        //GenerateRooms();
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

    // // // 

    void GenerateRooms()
    {//Room Generation Logic: -First room always has to be a SpawnRoom, -check every door(N,S,W,E) and generate a room in this direction after the actual room.

        //Fill the RoomTypes 2D Array:
        int enemyRoomNb = 0;
        rooms[0,0] = RoomType.Spawn;

        for (int i = 1; i < rooms.Length; i++)
        {
            for (int j = 1; j < rooms.Length; j++)
            {
                if (enemyRoomNb >= 25) //If 25 EnnemyRoom was generated, generate a BossRoom
                {
                    rooms[i, j] = RoomType.Boss;
                    enemyRoomNb = 0; //Then reset the number of enemyRoom generated
                }
                else
                {
                    rooms[i, j] = RoomType.Enemy;
                    enemyRoomNb++;
                }
            }
        }

    }

    public RoomType RoomTypeOfDir(Vector2Int roomPos, Directions dir)
    {
        RoomType retour = RoomType.None;
        //check roomtype of the 4 neighbors (N, S, W, E)
        switch (dir)
        {
            case Directions.North:
                retour = rooms[roomPos.x, roomPos.y + 1];
                break;
            case Directions.South:
                retour = rooms[roomPos.x, roomPos.y - 1];
                break;
            case Directions.East:
                retour = rooms[roomPos.x + 1, roomPos.y];
                break;
            case Directions.West:
                retour = rooms[roomPos.x - 1, roomPos.y];
                break;
            default:
                break;
        }

        //return the roomType of the wanted dir
        return retour;
    }

    public void GoToNextRoom(Vector2Int pos, Directions dir)
    {
       //. currentRoom = GameObject.Instantiate(Resources.Load<GameObject>())
    }

    public void SetCurrentRoomRandomly(RoomType roomType)
    {
        //set room type path
        string roomPath = "Prefabs/Room/" + roomType.ToString() + "/";

        //now grab a room in this folder randomly
        string roomName = "";

        switch (roomType)
        {
            case RoomType.Spawn:
                roomName = "SpawnRoom";
                break;
            case RoomType.Enemy:
                roomName = "EnemyRoom";
                break;
            case RoomType.None:
                Debug.Log("RoomType is null");
                break;
            default:
                break;
        }

        roomPath += roomName;

        //then instantiate the room and store it into currentRoom
        currentRoom = GameObject.Instantiate(Resources.Load<GameObject>(roomPath));
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

}
