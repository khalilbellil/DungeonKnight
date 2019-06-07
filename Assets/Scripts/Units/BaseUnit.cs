using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    private int health = 100;

    bool isAlive;
    // weapon[] wpns;
    //int wpnIndex = 0;

    public Rigidbody2D rb;

    virtual public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("basic init");
    }
    
    virtual public void UnitUpdate()
    {
        Debug.Log("basic update");
    }

    virtual public void UnitFixedUpdate()
    {
        Debug.Log("basic fixedupdate");
    }

    virtual public void death()
    {
        Debug.Log("basic isDead");
        isAlive = false;
    }

    public void useWeapon(Vector2 dir) {
        if(Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log("basic use weapon");
    }

    public void UpdateMovement(Vector2 dir)
    {
        UseDash(dir);

    }

    public void UseDash(Vector2 dir)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Dash");
        }
    }

    public void TakeDamage()
    {
        Debug.Log("basic takedamage");
    }



}
