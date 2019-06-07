using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum RoomType { Spawn, Enemy, Boss, Shop, None}
public enum Directions { North,South,East,West}

public class GeneriqueRooms : MonoBehaviour
{
    int lvl;
    string namePath;
    int numOfDoors;
    RoomType[] doors;
    public GameObject north;
    public GameObject south;
    public GameObject east;
    public GameObject west;
    public Tilemap tileDoors;
    public Dictionary<RoomType, Color> doorColorDic = new Dictionary<RoomType, Color>() {
        { RoomType.Boss, new Color(1f,.84f,0f,1) },
        { RoomType.Enemy, new Color(.5f,.5f,.5f,1) },
        { RoomType.Shop, new Color(1f,0f,0f,1) },
        { RoomType.Spawn, new Color(.5f,.5f,.5f,1) }
    };
    
    // Start is called before the first frame update
    public virtual void Initialize(int _lvl, RoomType[] _doors)
    {
        
        doors = _doors;
        north.SetActive(doors[0] == RoomType.None);
        east.SetActive(doors[1] == RoomType.None);
        south.SetActive(doors[2] == RoomType.None);
        west.SetActive(doors[3] == RoomType.None);
        //doors[1]  east
        //doors[2]  south
        //doors[3]  west
    }

    // Update is called once per frame
    public virtual void RoomUpdate()
    {
        
    }

    public virtual void Close()
    {

    }

    public virtual void LockDoors()
    {
        north.SetActive(true);
        east.SetActive(true);
        south.SetActive(true);
        west.SetActive(true);
    }

    public virtual void UnlockDoors()
    {
        north.SetActive(false);
        east.SetActive(false);
        south.SetActive(false);
        west.SetActive(false);
    }

    public void ColorDoor(RoomType door,Directions dir)
    {
        Tilemap tm = tileDoors;
        Color newDoorColor = doorColorDic[door];

        switch (dir)
        {
            case Directions.North:
                tm.SetColor(new Vector3Int(11, 1, 0), newDoorColor);
                tm.SetColor(new Vector3Int(12, 1, 0), newDoorColor);
                break;
            case Directions.South:
                tm.SetColor(new Vector3Int(11, 10, 0), newDoorColor);
                tm.SetColor(new Vector3Int(12, 10, 0), newDoorColor);
                break;
            case Directions.East:
                tm.SetColor(new Vector3Int(21, 6, 0), newDoorColor);
                tm.SetColor(new Vector3Int(21, 7, 0), newDoorColor);
                break;
            case Directions.West:
                tm.SetColor(new Vector3Int(0, 6, 0), newDoorColor);
                tm.SetColor(new Vector3Int(0, 7, 0), newDoorColor);
                break;
            default:
                break;
        }
    }
}
