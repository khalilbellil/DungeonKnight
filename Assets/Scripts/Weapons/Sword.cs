using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{

    #region Sword Stats:
    [Header("Sword Specific:")]
    [SerializeField] private int hitFrames;     //ammount of frame the weapon will be able to hit something
    #endregion


    public override void Init()
    {
        base.Init();
    }

    public override void WeaponUpdate()
    {
        base.WeaponUpdate();
    }

    public override void WeaponFixedUpdate()
    {
        base.WeaponFixedUpdate();
    }

    public override void Attack(Vector2 dir)
    {


        base.Attack(dir);
    }

}
