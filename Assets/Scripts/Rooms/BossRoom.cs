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
        foreach (Enemy e in EnemyManager.Instance.enemiesAlive)
        {
            e.transform.position = new Vector3(22, 12, 0);
        }
    }

    public void TrapTriggerEntered(Transform thingEnteredDoor)
    {
        GameObject.FindObjectOfType<MainEntry>().GoToNextFlow(CurrentState.Menu);
    }
}
