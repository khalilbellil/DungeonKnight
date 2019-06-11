using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BaseUnit
{
    override public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("enemy init");
    }

    override public void UnitUpdate()
    {
        Debug.Log("enemy update");
    }

    override public void UnitFixedUpdate()
    {
        Debug.Log("enemy fixedupdate");
    }

    override public void Death()
    {
        Debug.Log("enemy isDead");
        DropItem();
        isAlive = false;
    }

    override public void MovementAnimations()
    {
        Debug.Log("enemy animation");
    }

    public void MoveTo(Vector2 goalPos)
    {
        Vector2 dir = (goalPos - (Vector2)transform.position).normalized;
        Debug.Log("enemy isMoving");
        UpdateMovement(dir);
    }

    public void DropItem()
    {
        Debug.Log("enemy Droped item");
    }


}


