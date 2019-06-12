using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    Vector2 centre;
    protected float range;
    public override void Init(string hitableLayer)
    {
        range = 1;
        base.Init(hitableLayer);
        hitBoxSize = new Vector2(1.5f, 1.5f);

    }

    public override void WeaponUpdate()
    {
        base.WeaponUpdate();
    }

    public override void WeaponFixedUpdate()
    {
        base.WeaponFixedUpdate();
    }

    public override void Attack(Vector2 dir, Vector2 casterLocation)
    {
        dir.Normalize();
        float angle = Mathf.Atan(dir.y / dir.x) * Mathf.Rad2Deg;
        
        Collider2D[] targetsHit = Physics2D.OverlapBoxAll(casterLocation , hitBoxSize, angle, layerToHit);      //Creates a box and returns all colliders with Layer named "Enemy" inside it 
 //       if (angle >= 180)
 //       {
 //           angle -= 360;
 //       }
        Debug.Log("Angle: " + angle);
        Debug.Log("Direction : " + dir);
        foreach (Collider2D target in targetsHit)
        {
            target.gameObject.GetComponent<BaseUnit>()?.TakeDamage(dammage);
        }
        base.Attack(dir, casterLocation);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(centre, hitBoxSize);

    }
}
