using UnityEngine;

public struct RoomData
{
    public Vector2Int pos;
    public RoomType roomType;
    public bool isCleared;

    public int roomSet;
    public bool roomSetted;

    public bool northDoor;
    public bool westDoor;
    public bool southDoor;
    public bool eastDoor;
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

    public RoomData[,] roomsArray = new RoomData[10, 10];//All the rooms data pckg are generated and saved here

    public GameObject currentRoom; //The room where the player is.
    GeneriqueRooms currentRoomG;
    Directions dirPlayerCameFrom; //Direction the player came from (example: If he takes the North Door, in the next room he will be exiting the South Door)

    //Spawn locations of the player when he change room
    Vector2Int playerSpawnNorth = new Vector2Int(23, 21);
    Vector2Int playerSpawnWest = new Vector2Int(2, 13);
    Vector2Int playerSpawnSouth = new Vector2Int(23, 3);
    Vector2Int playerSpawnEast = new Vector2Int(42, 13);

    Player player;

    // // // 

    public void Initialize()
    {//Generate Rooms
        player = PlayerManager.Instance.player;
        currentRoom = GameObject.FindObjectOfType<GeneriqueRooms>().gameObject;
        currentRoomG = currentRoom.GetComponent<GeneriqueRooms>();
        GenerateRooms();
        Debug.Log("Room Generated");
    }

    public void UpdateManager()
    {
        ChangeRoom(player);
        currentRoomG.RoomUpdate();
    }

    public void FixedUpdateManager()
    {

    }

    public void StopManager()
    {
        instance = null;
    }

    // // // 

    public RoomData roomDataContructor()
    {
        RoomData roomData;
        roomData = new RoomData { pos = new Vector2Int(0, 0), roomType = RoomType.None, isCleared = false, roomSet = 0, roomSetted = false, northDoor = false, westDoor = false, southDoor = false, eastDoor = false };
        return roomData;
    }

    void GenerateRooms()
    {//Room Generation Logic: -First room always has to be a SpawnRoom, -check every door(N,S,W,E) and generate a room in this direction after the actual room.

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                roomsArray[i, j] = roomDataContructor();
                int x = Random.Range(0, 3);
                roomsArray[i, j].roomType = (RoomType)x;
                roomsArray[i, j].pos = new Vector2Int(i, j);
            }
        }

        roomsArray[0, 0].roomType = RoomType.Spawn; //First room always a Spawn Room
        InstantiateRoom(new Vector2Int(0, 0));
    }

    public void InstantiateRoom(Vector2Int roomPos)
    {
        RoomType roomType = RoomType.None;
        roomType = roomsArray[roomPos.x, roomPos.y].roomType;

        currentRoom.GetComponent<GeneriqueRooms>().Close();
        EnemyManager.Instance.enemiesAlive.Clear();
        GameObject.Destroy(currentRoom);

        switch (roomType)
        {
            case RoomType.Enemy:
                currentRoom = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.ennemyRoomDir));//Instantiate the prefab
                currentRoom.GetComponent<GeneriqueRooms>().Initialize(roomsArray[roomPos.x, roomPos.y], SetDoors(roomPos));//Initialize the room and give it the data pckg
                currentRoomG = currentRoom.GetComponent<GeneriqueRooms>();
                break;
            case RoomType.Boss:
                currentRoom = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.bossRoomDir));
                currentRoom.GetComponent<GeneriqueRooms>().Initialize(roomsArray[roomPos.x, roomPos.y], SetDoors(roomPos));
                currentRoomG = currentRoom.GetComponent<GeneriqueRooms>();
                break;
            case RoomType.Shop:
                currentRoom = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.ennemyRoomDir));
                currentRoom.GetComponent<GeneriqueRooms>().Initialize(roomsArray[roomPos.x, roomPos.y], SetDoors(roomPos));
                currentRoomG = currentRoom.GetComponent<GeneriqueRooms>();
                break;
            case RoomType.Spawn:
                currentRoom = GameObject.Instantiate(Resources.Load<GameObject>(PrefabsDir.spawnRoomDir));
                currentRoom.GetComponent<GeneriqueRooms>().Initialize(roomsArray[roomPos.x, roomPos.y], SetDoors(roomPos));
                currentRoomG = currentRoom.GetComponent<GeneriqueRooms>();
                break;
            case RoomType.None:
                break;
            default:
                break;
        }
        Debug.Log("RoomPos: " + currentRoom.GetComponent<GeneriqueRooms>().roomData.pos);
    }

    public RoomType[] SetDoors(Vector2Int pos)
    {//Activate the existing doors
        RoomType[] doors = new RoomType[4];

        if (pos.x == 0)
        {//Close West Door
            roomsArray[pos.x, pos.y].westDoor = false;//Save the door state in roomsArray
            doors[3] = RoomType.None;
        }
        else
        {
            doors[3] = RoomTypeOfDir(pos, Directions.West);
        }

        if (pos.y == 0)
        {//Close South Door
            roomsArray[pos.x, pos.y].southDoor = false;//Save the door state in roomsArray
            doors[2] = RoomType.None;
        }
        else
        {
            doors[2] = RoomTypeOfDir(pos, Directions.South);
        }

        if (pos.x == 9)
        {//Close East Door
            roomsArray[pos.x, pos.y].eastDoor = false;//Save the door state in roomsArray
            doors[1] = RoomType.None;
        }
        else
        {
            doors[1] = RoomTypeOfDir(pos, Directions.East);
        }

        if (pos.y == 9)
        {//Close North Door
            roomsArray[pos.x, pos.y].northDoor = false;//Save the door state in roomsArray
            doors[0] = RoomType.None;
        }
        else
        {
            doors[0] = RoomTypeOfDir(pos, Directions.North);
        }

        return doors;
    }

    void ChangeRoom(Player player)
    {
        GeneriqueRooms currentGeneriqueRoom = currentRoom.GetComponent<GeneriqueRooms>();

        if (player.transform.position.x >= 21 && player.transform.position.x <= 23 && player.transform.position.y >= 22 && player.transform.position.y <= 25)
        {//North Door Activated
            if (!currentGeneriqueRoom.north.activeSelf)//Check if door is open
            {
                InstantiateRoom(currentGeneriqueRoom.roomData.pos + new Vector2Int(0, 1));
                player.transform.position = new Vector3(playerSpawnSouth.x, playerSpawnSouth.y, 0);//Set player position
            }
        }
        if (player.transform.position.x >= 0.5f && player.transform.position.x <= 1 && player.transform.position.y >= 11 && player.transform.position.y <= 13)
        {//West Door Activated
            if (!currentGeneriqueRoom.west.activeSelf)//Check if door is open
            {
                InstantiateRoom(currentGeneriqueRoom.roomData.pos - new Vector2Int(1, 0));
                player.transform.position = new Vector3(playerSpawnEast.x, playerSpawnEast.y, 0);//Set player position
            }
        }
        if (player.transform.position.x >= 21 && player.transform.position.x <= 23 && player.transform.position.y >= 0.5f && player.transform.position.y <= 2)
        {//South Door Activated
            if (!currentGeneriqueRoom.south.activeSelf)//Check if door is open
            {
                InstantiateRoom(currentGeneriqueRoom.roomData.pos - new Vector2Int(0, 1));
                player.transform.position = new Vector3(playerSpawnNorth.x, playerSpawnNorth.y, 0);//Set player position
            }
        }
        if (player.transform.position.x >= 43 && player.transform.position.x <= 43.5f && player.transform.position.y >= 11 && player.transform.position.y <= 13)
        {//East Door Activated
            if (!currentGeneriqueRoom.east.activeSelf)//Check if door is open
            {
                InstantiateRoom(currentGeneriqueRoom.roomData.pos + new Vector2Int(1, 0));
                player.transform.position = new Vector3(playerSpawnWest.x, playerSpawnWest.y, 0);//Set player position
            }
        }
    }

    public RoomType RoomTypeOfDir(Vector2Int roomPos, Directions dir)
    {
        RoomType retour = RoomType.None;
        ////check roomtype of the 4 neighbors (N, S, W, E)
        switch (dir)
        {
            case Directions.North:
                retour = roomsArray[roomPos.x, roomPos.y + 1].roomType;
                break;
            case Directions.South:
                retour = roomsArray[roomPos.x, roomPos.y - 1].roomType;
                break;
            case Directions.East:
                retour = roomsArray[roomPos.x + 1, roomPos.y].roomType;
                break;
            case Directions.West:
                retour = roomsArray[roomPos.x - 1, roomPos.y].roomType;
                break;
            default:
                break;
        }

        //return the roomType of the wanted dir
        return retour;
    }

}
