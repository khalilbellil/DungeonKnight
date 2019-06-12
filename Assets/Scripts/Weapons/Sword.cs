﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    Vector2 centre;
    protected float range;
    public override void Init(string hitableLayer)
    {
        range = 1;
        hitBoxSize = new Vector2(1.5f, 1.5f);
        base.Init(hitableLayer);



    }

    public override void WeaponUpdate(float dt)
    {
        base.WeaponUpdate(dt);
    }

    public override void WeaponFixedUpdate()
    {
        base.WeaponFixedUpdate();
    }

    public override void Attack(Vector2 dir, Vector2 casterLocation, float dt)
    {
        if (attackAvailable)
        {
            attackAvailable = false;

            dir.Normalize();
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            angle = -angle;
            //angle = Vector2.Angle(new Vector2(1, 1), dir);

            if (angle >= 180)
            {
                angle -= 360;
            }
            Collider2D[] targetsHit = Physics2D.OverlapBoxAll(casterLocation, hitBoxSize, angle, layerToHit);      //Creates a box and returns all colliders with Layer named "Enemy" inside it 
            Debug.Log("Angle: " + angle);
            Debug.Log("Direction : " + dir);
            foreach (Collider2D target in targetsHit)
            {
                target.gameObject.GetComponent<BaseUnit>()?.TakeDamage(dammage);
            }
            base.Attack(dir, casterLocation, dt);
        }
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(centre, hitBoxSize);

    }
}
