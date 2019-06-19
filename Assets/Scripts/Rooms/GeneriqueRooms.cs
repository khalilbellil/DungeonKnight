﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum RoomType { Enemy, Boss, Shop, Spawn, None }
public enum Directions { North,South,East,West}

public class GeneriqueRooms : MonoBehaviour
{
    public Vector2Int posInRoomM;

    public bool isCleared = false;

    protected int lvl;
    string namePath;
    int numOfDoors;
    public RoomType roomType;
    public RoomType[] doors;
    public GameObject north;
    public GameObject south;
    public GameObject east;
    public GameObject west;
    public Tilemap tileDoors;
    
    ArrayList coins = new ArrayList(); //Keep track of existing coins.

    public Dictionary<RoomType, Color> doorColorDic = new Dictionary<RoomType, Color>() {
        { RoomType.Boss, new Color(1f,.84f,0f,1) },
        { RoomType.Enemy, new Color(.5f,.5f,.5f,1) },
        { RoomType.Shop, new Color(1f,0f,0f,1) },
        { RoomType.Spawn, new Color(.5f,.5f,.5f,1) },
        { RoomType.None, new Color(.5f,.5f,.5f,0) }
    };

    // Start is called before the   first frame update
    public virtual void Initialize(int _lvl, RoomType[] _doors)
    {
        lvl = _lvl;   
        doors = _doors;
        // roomType = _roomtype;

        //north.SetActive(doors[0] == RoomType.None);
        //east.SetActive(doors[1] == RoomType.None);
        //south.SetActive(doors[2] == RoomType.None);
        //west.SetActive(doors[3] == RoomType.None);

        

        ColorDoor(doors[0], Directions.North);
        ColorDoor(doors[1], Directions.East);
        ColorDoor(doors[2], Directions.South);
        ColorDoor(doors[3], Directions.West);

        Grid.InitBoolGrid();

        foreach (CompositeCollider2D c in GetComponentsInChildren<CompositeCollider2D>())
        {
            c.geometryType = CompositeCollider2D.GeometryType.Outlines;
        }


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

    public virtual void SetDoors(Vector2Int pos)
    {//Activate the existing doors
        north.SetActive(false);
        east.SetActive(false);
        south.SetActive(false);
        west.SetActive(false);

        if (pos.x == 0)
        {
            west.SetActive(true);
        }

        if (pos.y == 0)
        {
            south.SetActive(true);
        }

        if (pos.x == 9)
        {
            north.SetActive(true);
        }

        if (pos.y == 9)
        {
            east.SetActive(true);
        }

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

    public void ColorDoor(RoomType door,Directions dir)
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

    public void DoorTriggerEntered(Transform thingEnteredDoor)
    {
        
        Debug.Log("thing entered door: " + thingEnteredDoor.name);
        //once confirmed is player & location
        if (thingEnteredDoor.CompareTag("Player"))
        {
            if(thingEnteredDoor.position.x <= 21 && thingEnteredDoor.position.x >= 23)
            {
                if(thingEnteredDoor.position.y >= 22)
                {
                    RoomManager.Instance.RoomExited(Directions.North);
                }
                else if(thingEnteredDoor.position.y <= 3)
                {
                    RoomManager.Instance.RoomExited(Directions.South);
                }
            }
            else if (thingEnteredDoor.position.y <= 11 && thingEnteredDoor.position.y >= 13)
            {
                if (thingEnteredDoor.position.x >= 43)
                {
                    RoomManager.Instance.RoomExited(Directions.East);
                }
                else if (thingEnteredDoor.position.x <= 1)
                {
                    RoomManager.Instance.RoomExited(Directions.West);
                }
            }
        }
        //calculate which direction
        //RoomManager.Instance.RoomExited(Directions.North)
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}
