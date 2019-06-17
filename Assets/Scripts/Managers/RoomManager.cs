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

    Player player;

    // // // 

    public void Initialize()
    {//Generate Rooms
        currentRoom = GameObject.FindObjectOfType<GeneriqueRooms>().gameObject;

        //SetCurrentRoomRandomly(RoomType.Spawn);
        GenerateRooms();
        //currentRoom.GetComponent<GeneriqueRooms>().north.SetActive(true);

        player = PlayerManager.Instance.player;
    }

    public void UpdateManager()
    {
        ChangeRoom(player);
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
        rooms[0, 0] = RoomType.Spawn; //First room always a Spawn Room

        InstantiateRoom(new Vector2Int(0, 0));

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (i != 0 && j != 0)
                {
                    int x = Random.Range(1, 3);
                    rooms[i, j] = (RoomType)x;
                }
            }
        }
    }

    public void InstantiateRoom(Vector2Int roomPos)
    {
        RoomType roomType = rooms[roomPos.x, roomPos.y];
        GameObject.Destroy(currentRoom);
        switch (roomType)
        {
            case RoomType.Enemy:
                currentRoom = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.ennemyRoomDir));
                currentRoomPos = roomPos;
                currentRoom.GetComponent<GeneriqueRooms>().posInRoomM = roomPos;
                SetDoors2(roomPos, currentRoom.GetComponent<GeneriqueRooms>());
                break;
            case RoomType.Boss:
                currentRoom = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.ennemyRoomDir));
                currentRoomPos = roomPos;
                currentRoom.GetComponent<GeneriqueRooms>().posInRoomM = roomPos;
                SetDoors2(roomPos, currentRoom.GetComponent<GeneriqueRooms>());
                break;
            case RoomType.Shop:
                currentRoom = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.spawnRoomDir));
                currentRoomPos = roomPos;
                currentRoom.GetComponent<GeneriqueRooms>().posInRoomM = roomPos;
                SetDoors2(roomPos, currentRoom.GetComponent<GeneriqueRooms>());
                break;
            case RoomType.Spawn:
                currentRoom = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.spawnRoomDir));
                currentRoomPos = roomPos;
                currentRoom.GetComponent<GeneriqueRooms>().posInRoomM = roomPos;
                SetDoors2(roomPos, currentRoom.GetComponent<GeneriqueRooms>());
                break;
            case RoomType.None:
                break;
            default:
                break;
        }
    }

    public void SetDoors2(Vector2Int pos, GeneriqueRooms room)
    {//Activate the existing doors
        room.north.SetActive(false);
        room.east.SetActive(false);
        room.south.SetActive(false);
        room.west.SetActive(false);

        if (pos.x == 0)
        {
            room.west.SetActive(true);
        }

        if (pos.y == 0)
        {
            room.south.SetActive(true);
        }

        if (pos.x == 9)
        {
            room.north.SetActive(true);
        }

        if (pos.y == 9)
        {
            room.east.SetActive(true);
        }

    }

    void ChangeRoom(Player player)
    {
        if (player.transform.position.x >= 21 && player.transform.position.x <= 23 && player.transform.position.y >= 22 && player.transform.position.y <= 25)
        {//North Door Activated
            if (!currentRoom.GetComponent<GeneriqueRooms>().north.activeSelf)
            {
                InstantiateRoom(currentRoomPos + new Vector2Int(0, 1));
            }
        }
        if (player.transform.position.x >= 0.5f && player.transform.position.x <= 1 && player.transform.position.y >= 11 && player.transform.position.y <= 13)
        {//West Door Activated
            if (!currentRoom.GetComponent<GeneriqueRooms>().west.activeSelf)
            {
                InstantiateRoom(currentRoomPos - new Vector2Int(1, 0));
            }
        }
        if (player.transform.position.x >= 21 && player.transform.position.x <= 23 && player.transform.position.y >= 0.5f && player.transform.position.y <= 2)
        {//South Door Activated
            if (!currentRoom.GetComponent<GeneriqueRooms>().south.activeSelf)
            {
                InstantiateRoom(currentRoomPos - new Vector2Int(0, 1));
            }
        }
        if (player.transform.position.x >= 43 && player.transform.position.x <= 43.5f && player.transform.position.y >= 11 && player.transform.position.y <= 13)
        {//East Door Activated
            if (!currentRoom.GetComponent<GeneriqueRooms>().east.activeSelf)
            {
                InstantiateRoom(currentRoomPos + new Vector2Int(1, 0));
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
