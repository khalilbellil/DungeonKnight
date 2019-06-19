using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyRoom : GeneriqueRooms
{
    int roomSet;
    public bool roomSetted = false;

    public override void Initialize(int _lvl, RoomType[] _doors)
    {
        roomType = RoomType.Enemy;
        base.Initialize(_lvl, _doors);

        //Choose the roomset using index of child
        if (!roomSetted)
        {
            roomSet = Random.Range(0, transform.GetChild(8).childCount);
            roomSetted = true;
        }


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
        int numOfEnemies = Mathf.Clamp(lvl / 3, 2, 10);
        int x;
        int y;

        for(int i = 0; i < numOfEnemies; i++)
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
