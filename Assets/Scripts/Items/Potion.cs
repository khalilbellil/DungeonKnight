using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : Item
{
    public int regenValue = 20;
    public override void Init()
    {
        base.Init();
        itemType = AllItems.potion;
    }

    protected override void CollidedWithPlayer(Player player)
    {
        //Heal applied to player
        player.health = Mathf.Clamp(player.health + regenValue, 0, player.maxHealth);
       
    }
}
