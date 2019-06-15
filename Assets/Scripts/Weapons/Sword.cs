using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    protected float range;

    public override void Init(LayerMask hitableLayer, BaseUnit _owner)
    {
        range = 2;
        hitBoxSize = new Vector2(1.5f, 1.5f);
        base.Init(hitableLayer, _owner);
        animTrigger = "UseSword";
    }

    public override void WeaponUpdate(float dt)
    {
        base.WeaponUpdate(dt);
    }

    public override void WeaponFixedUpdate()
    {
        base.WeaponFixedUpdate();
    }

    public override void Attack(Vector2 dir, Vector2 casterLocation)
    {

        if (attackAvailable)
        {
            attackAvailable = false;

            Vector2 hitBoxLocation = casterLocation + dir * range;
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            angle = -angle;

            if (angle >= 180)
            {
                angle -= 360;
            }

            Collider2D[] targetsHit = Physics2D.OverlapBoxAll(hitBoxLocation, hitBoxSize * range, angle, layerToHit);      //Creates a box and returns all colliders with Layer named "Enemy" inside it 

          //  Debug.Log("Angle: " + angle);
           // Debug.Log("Direction : " + dir);

            foreach (Collider2D target in targetsHit)
            {
                target.gameObject.GetComponent<BaseUnit>()?.TakeDamage(dammage);
            }
            base.Attack(dir, casterLocation);

            DrawHitBox(true, angle, hitBoxLocation, hitBoxSize);

        }
    }

    private void DrawHitBox(bool drawBox, float rot, Vector2 center,Vector2 size)
    {
        GameObject hitbox = new GameObject() ;
        hitbox.AddComponent<SpriteRenderer>();
        hitbox.GetComponent<SpriteRenderer>().sprite = Sprite.Create(Texture2D.whiteTexture, new Rect(0,0,size.x,size.y), new Vector2(.5f,.5f), 1);
        hitbox.transform.position = center;
        hitbox.transform.eulerAngles = new Vector3(0, 0, rot);
       // Debug.LogError("");
        hitbox.GetComponent<SpriteRenderer>().sortingLayerName = "Player";
        GameObject.Destroy(hitbox, 2);
    }
}
