using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{

    #region VARIABLES
    public bool isAlive;
    #endregion
    
    #region Unit Stats
    [Header("Unit Stats:")]
    private int health = 100;
    private int speed = 10;
    private double critChance = 0.05;
    private double critMultipier = 1.5;
    #endregion

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
            Debug.Log("basic use weapon");
    }

    virtual public void UpdateMovement(Vector2 dir)
    {

        Debug.Log("Movement: " + dir);

    }

    public void UseDash(Vector2 dir)
    {
        
            Debug.Log("Dash");
        

     //   rb.AddForce(dir * speed);

    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("basic takedamage");
    }

}
