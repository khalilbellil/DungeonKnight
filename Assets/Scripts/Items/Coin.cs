using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
	int value = 1;
	public override void Init()
	{
		base.Init();
		itemType = AllItems.coin;
	}

	protected override void CollidedWithPlayer(Player player)
	{
		player.coins += value;
	}
}