using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BossRoom : GeneriqueRooms
{

    public override void Initialize(int _lvl, RoomType[] _doors)
    {
        roomType = RoomType.Boss;
        base.Initialize(_lvl, _doors);
        if (!isCleared)
        {
            LockDoors();
        }
        //Set boss spawn coordinates
        Spawn();
    }

    public override void RoomUpdate()
    {
        base.RoomUpdate();
        if (EnemyManager.Instance.enemiesAlive.Count == 0)
        {
            transform.GetChild(8).gameObject.SetActive(true);
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
        EnemyManager.Instance.SpawnBoss(new Vector2(22,12));
    }

    public void TrapTriggerEntered(Transform thingEnteredDoor)
    {
        GameFlow.isGame = false;
        UIManager.Instance.CallWinScreen();
    }
}