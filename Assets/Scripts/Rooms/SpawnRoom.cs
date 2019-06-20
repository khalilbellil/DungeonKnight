using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : GeneriqueRooms
{
    public override void Initialize(int _lvl, RoomType[] _doors)
    {
        base.Initialize(_lvl, _doors);
        PlayerManager.Instance.player.transform.position = new Vector3();
        EnemyManager.Instance.SpawnEnemy(0,new Vector2(40,12));
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
