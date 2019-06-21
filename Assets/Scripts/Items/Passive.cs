using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passive : Item
{
    public PassiveType passiveType;
    float speedMultip = 1.25f;
    float criticMultip = 1.5f;
    float newMaxHp = 400f;

    float speedMultipDefault = 1f;
    float criticMultipDefault = 1f;
    float maxHpDefault = 300f;

    public override void Init()
    {
        base.Init();
        itemType = AllItems.passive;
    }

    protected override void CollidedWithPlayer(Player player)
    {
        if (player.passiveActive)
        {//remove previous passive effects before applying the new one
            player.maxHealth = maxHpDefault;
            player.speedMultiplier = speedMultipDefault;
            player.critMultipier = criticMultipDefault;
        }

        switch (passiveType)
        {
            case PassiveType.Healer:
                player.maxHealth = newMaxHp;
                player.health = player.maxHealth;
                UIManager.Instance.SetPassiveUI(PassiveType.Healer);
                player.passiveActive = true;
                break;
            case PassiveType.SpeedBoost:
                player.speedMultiplier = speedMultip;
                UIManager.Instance.SetPassiveUI(PassiveType.SpeedBoost);
                player.passiveActive = true;
                break;
            //case PassiveType.CriticBoost:
            //    player.critMultipier = criticMultip;
            //    player.passiveActive = true;
            //    break;
            default:
                break;
        }
        
    }

}
