using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : GeneriqueRooms
{
    public override void Initialize(RoomData roomData)
    {
        //base.Initialize(_lvl, _doors);
        //PlayerManager.Instance.player.transform.position = new Vector3();
        EnemyManager.Instance.SpawnEnemy(0,new Vector2(40,12));
        base.Initialize(roomData);
    }

    public override void RoomUpdate()
    {
        base.RoomUpdate();
    }

    public override void Close()
    {
        base.Close();
    }
}
