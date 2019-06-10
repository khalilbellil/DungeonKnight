using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseUnit : MonoBehaviour
{

    #region VARIABLES
    public bool isAlive;
    #endregion
    
    #region Unit Stats
    [Header("Unit Stats:")]
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private double critChance;
    [SerializeField] private double critMultipier;
    #endregion

    // weapon[] wpns;
    //int wpnIndex = 0;

    [HideInInspector] public Rigidbody2D rb;

    virtual public void Init()
    {
        isAlive = true;
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

    virtual public void MovementAnimations()
    {
        Debug.Log("basic animation");
    }

    
    public void useWeapon(Vector2 dir) {
            Debug.Log("basic use weapon");
    }

    virtual public void UpdateMovement(Vector2 dir)
    {
        float dt = Time.deltaTime;
        rb.velocity = dir * speed * Time.deltaTime;
       // this.transform.Translate(dir.x * dt * speed, dir.y * dt * speed, 0);

        rb.AddForce(dir * speed);


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
