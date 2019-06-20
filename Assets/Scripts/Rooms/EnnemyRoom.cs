﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyRoom : GeneriqueRooms
{
    int roomSet;
    public bool roomSetted = false;

    public override void Initialize(RoomData _roomData, RoomType[] _doors)
    {
        base.Initialize(_roomData, _doors);

        if (!roomData.roomSetted)//if room not setted yet, set it and save it
        {
            roomSet = Random.Range(0, transform.GetChild(8).childCount);//Randomly set the roomSet
            roomData.roomSet = roomSet;//Save the roomSet
            roomData.roomSetted = true;//Save that the room was setted
        }

        transform.GetChild(8).GetChild(roomData.roomSet).gameObject.SetActive(true);

        if (!isCleared)
        {
            LockDoors();
			Spawn();
		}
        //Set enemies spawn coordinates
    }

    public override void RoomUpdate()
    {
        base.RoomUpdate();
        if (EnemyManager.Instance.enemiesAlive.Count == 0)
        {
            UnlockDoors();
            isCleared = true;
        }
    }

    public override void Close()
    {
        roomData.roomSet = roomSet;
        roomData.roomSetted = roomSetted;
        base.Close();
    }

    void Spawn()
    {
        int numOfEnemies = Mathf.Clamp(lvl / 3, 2, 10);
        int x;
        int y;

        for (int i = 0; i < numOfEnemies; i++)
        {
            x = Random.Range(1, 43);
            y = Random.Range(2, 22);
            while (Physics2D.OverlapBox(new Vector2(x + .5f, y + .5f), new Vector2(.9f, .9f), 0, LayerMask.GetMask("Player", "Objects", "Walls", "RoomSet")) != null)
            {
                x = Random.Range(1, 43);
                y = Random.Range(2, 22);
            }

            EnemyManager.Instance.SpawnEnemy(lvl, new Vector2(x, y));
        }
    }
}
