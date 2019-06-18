using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowItem : Item
{
    
    public override void Init()
    {
        base.Init();
        itemType = AllItems.arrow;
    }

    protected override void CollidedWithPlayer(Player player)
    {
        player.arrowCount = player.maxArrowCount;

    }
}
