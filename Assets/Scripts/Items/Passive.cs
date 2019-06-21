using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : Item
{
    public PassiveType passiveType;
    public float speedMultip = 1.25f;
    public float criticMultip = 1.5f;
    public float newMaxHp = 200f;

    public override void Init()
    {
        base.Init();
        itemType = AllItems.passive;
    }

    protected override void CollidedWithPlayer(Player player)
    {
        switch (passiveType)
        {
            case PassiveType.Healer:
                player.maxHealth = newMaxHp;
                player.health = player.maxHealth;
                UIManager.Instance.SetPassiveUI(PassiveType.Healer);
                break;
            case PassiveType.SpeedBoost:
                player.speedMultiplier = speedMultip;
                UIManager.Instance.SetPassiveUI(PassiveType.SpeedBoost);
                break;
            case PassiveType.CriticBoost:
                player.critMultipier = criticMultip;
                break;
            default:
                break;
        }
        
    }

}
