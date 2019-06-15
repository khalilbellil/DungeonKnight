﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyRoom : GeneriqueRooms
{
    int roomSet;

    private void Start()
    {

        Initialize(1, new RoomType[] { RoomType.Boss, RoomType.Enemy, RoomType.Shop,RoomType.None});
    }

    public override void Initialize(int _lvl, RoomType[] _doors)
    {
        roomType = RoomType.Enemy;
        base.Initialize(_lvl, _doors);
        //Choose the roomset using index of child
        roomSet = Random.Range(0,transform.GetChild(8).childCount);
        transform.GetChild(8).GetChild(roomSet).gameObject.SetActive(true);
        if (!isCleared)
        {
            LockDoors();
        }
        //Set enemies spawn coordinates
        Spawn();
    }

    public override void RoomUpdate()
    {
        base.RoomUpdate();
        if(EnemyManager.Instance.enemiesAlive.Count == 0)
        {
            UnlockDoors();
            isCleared = true;
        }
    }

    public override void Close()
    {
        base.Close();
    }

    void Spawn()
    {
        int x;
        int y;

        foreach(Enemy e in EnemyManager.Instance.enemiesAlive)
        {
            x = Random.Range(1, 43);
            y = Random.Range(2, 22);
            while (Physics2D.OverlapBox(new Vector2(x + .5f, y + .5f), new Vector2(.9f, .9f), 0, LayerMask.GetMask("Player", "Objects", "Walls", "RoomSet")) != null)
            {
                x = Random.Range(1, 43);
                y = Random.Range(2, 22);
            }
            e.transform.position = new Vector3(x, y, 0);
        }
    }
}
