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
		if (!isPickup && player.arrowCount < player.maxArrowCount) {
			isPickup = true;
			// this makes player pick up 20 arrows because thats the max arrow count
			//player.arrowCount = player.maxArrowCount;
			player.arrowCount += 1; 
		}
	}
}
