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
        float angle = Mathf.Atan(dir.magnitude);
        Collider2D[] targetsHit = Physics2D.OverlapBoxAll(dir, hitBoxSize, angle, LayerMask.NameToLayer("Enemy"));      //Creates a box and returns all colliders with Layer named "Enemy" inside it 
        Gizmos.color = Color.red;
        Gizmos.DrawCube(new Vector3(dir.x, dir.y), new Vector3(hitBoxSize.x, hitBoxSize.y));

        foreach (Collider2D target in targetsHit)
        {
            target.gameObject.GetComponent<BaseUnit>().TakeDamage(dammage);
        }

        base.Attack(dir);
    }

}
