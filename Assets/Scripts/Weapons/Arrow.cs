using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Bow
{
    private Vector2 startingPos;
    private Vector2 dir;
    private bool isTravelling;
    private float distanceToCheck;      //distance to check with raycast in front of the arrow 
    private LayerMask hitableLayer;

    public void Init(Vector2 _startingPos, Vector2 _dir, LayerMask _hitableLayer)
    {
        startingPos = _startingPos;
        dir = _dir;
        isTravelling = true;
        hitableLayer = _hitableLayer;
        SpawnArrow();
    }

    public void UpdateArrow()
    {
        if (isTravelling)
        {
            
        }
    }
    
    public void SpawnArrow()
    {

    }

    public void Move()
    {
        this.transform.position = new Vector3(dir.x * arrowSpeed, dir.y * arrowSpeed);
    }

    public Collider2D CheckForCollision()
    {
        Collider2D targetHit;
        RaycastHit2D rcHit = Physics2D.Raycast(transform.position, dir, distanceToCheck, hitableLayer); ;

        targetHit = rcHit.collider;

        return targetHit;
    }

    public override void Attack(Vector2 dir, Vector2 casterLocation)
    {

        CheckForCollision();

        base.Attack(dir, casterLocation);
    }
}
