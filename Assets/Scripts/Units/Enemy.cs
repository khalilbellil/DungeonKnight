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

    override public void death()
    {
        Debug.Log("enemy isDead");
        isAlive = false;
    }

    public void MovementAnimations()
    {
        Debug.Log("enemy animation");
    }
}
