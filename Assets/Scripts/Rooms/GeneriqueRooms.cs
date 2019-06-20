using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum RoomType { Enemy, Boss, Shop, Spawn, None }
public enum Directions { North, South, East, West }

public class GeneriqueRooms : MonoBehaviour
{
    public RoomData roomData;
    
    public bool isCleared = false;
    protected int lvl;

    public GameObject north;
    public GameObject south;
    public GameObject east;
    public GameObject west;
    public RoomType[] doors; //RoomType of each door, 0= north, 1= east, 2= south, 4= west
    public Tilemap tileDoors;

    public Dictionary<RoomType, Color> doorColorDic = new Dictionary<RoomType, Color>() {
        { RoomType.Boss, new Color(1f,.84f,0f,1) },
        { RoomType.Enemy, new Color(.5f,.5f,.5f,1) },
        { RoomType.Shop, new Color(1f,0f,0f,1) },
        { RoomType.Spawn, new Color(.5f,.5f,.5f,1) },
        { RoomType.None, new Color(.5f,.5f,.5f,0) }
    };

    public virtual void Initialize(RoomData _roomData, RoomType[] _doors)
    {
        roomData = _roomData;
        isCleared = roomData.isCleared;
        doors = _doors;

        north.SetActive(doors[0] == RoomType.None);
        east.SetActive(doors[1] == RoomType.None);
        south.SetActive(doors[2] == RoomType.None);
        west.SetActive(doors[3] == RoomType.None);

        ColorDoor(doors[0], Directions.North);
        ColorDoor(doors[1], Directions.East);
        ColorDoor(doors[2], Directions.South);
        ColorDoor(doors[3], Directions.West);

        Grid.InitBoolGrid();

        foreach (CompositeCollider2D c in GetComponentsInChildren<CompositeCollider2D>())
        {
            c.geometryType = CompositeCollider2D.GeometryType.Outlines;
        }
    }

    public virtual void RoomUpdate()
    {

    }

    public virtual void Close()
    {
        //Save the RoomData in the RoomManager roomsArray
        roomData.isCleared = isCleared;
        RoomManager.Instance.roomsArray[roomData.pos.x, roomData.pos.y] = roomData;
    }

    public virtual void LockDoors()
    {
        north.SetActive(true);
        east.SetActive(true);
        south.SetActive(true);
        west.SetActive(true);
        tileDoors.GetComponent<TilemapCollider2D>().enabled = false;
    }

    public virtual void UnlockDoors()
    {
        north.SetActive(doors[0] == RoomType.None);
        east.SetActive(doors[1] == RoomType.None);
        south.SetActive(doors[2] == RoomType.None);
        west.SetActive(doors[3] == RoomType.None);
        tileDoors.GetComponent<TilemapCollider2D>().enabled = true;
    }

    public void ColorDoor(RoomType door, Directions dir)
    {
        Tilemap tm = tileDoors;
        Color newDoorColor = doorColorDic[door];
        Vector3Int pos0, pos1;
        pos0 = pos1 = new Vector3Int();

        switch (dir)
        {
            case Directions.North:
                pos0 = new Vector3Int(-1, 10, 0);
                pos1 = new Vector3Int(0, 10, 0);
                //tm.SetColor(new Vector3Int(11, 1, 0), newDoorColor);
                //tm.SetColor(new Vector3Int(12, 1, 0), newDoorColor);
                break;
            case Directions.South:
                pos0 = new Vector3Int(-1, -11, 0);
                pos1 = new Vector3Int(0, -11, 0);
                //tm.SetColor(new Vector3Int(11, 10, 0), newDoorColor);
                //tm.SetColor(new Vector3Int(12, 10, 0), newDoorColor);
                break;
            case Directions.East:
                pos0 = new Vector3Int(21, 0, 0);
                pos1 = new Vector3Int(21, -1, 0);
                //tm.SetColor(new Vector3Int(21, 6, 0), newDoorColor);
                //tm.SetColor(new Vector3Int(21, 7, 0), newDoorColor);
                break;
            case Directions.West:
                pos0 = new Vector3Int(-22, 0, 0);
                pos1 = new Vector3Int(-22, -1, 0);
                //tm.SetColor(new Vector3Int(0, 6, 0), newDoorColor);
                //tm.SetColor(new Vector3Int(0, 7, 0), newDoorColor);
                break;
            default:
                break;
        }
        //newDoorColor.a = .1f;
        //pos0 = new Vector3Int(-1,4,0);
        //pos1 = new Vector3Int(0,4,0);
        tm.SetTileFlags(pos0, TileFlags.None);
        tm.SetTileFlags(pos1, TileFlags.None);
        tm.SetColor(pos0, newDoorColor);
        tm.SetColor(pos1, newDoorColor);
    }

}
