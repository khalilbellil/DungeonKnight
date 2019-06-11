using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BaseUnit : MonoBehaviour
{
    public Weapon[] weaponList;

    #region VARIABLES
    public bool isAlive;
    public int activeWeaponIndex;  //  0 = Sword, 1 = Bow (not implemented yet)
    #endregion
    
    #region Unit Stats
    [Header("Unit Stats:")]
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private double critChance;
    [SerializeField] private double critMultipier;
    #endregion

    [HideInInspector] public Rigidbody2D rb;

    // // //

    virtual public void Init()
    {
        isAlive = true;
        activeWeaponIndex = 0;

        weaponList = new Weapon[2];

        weaponList[0] = new Sword();
       //weaponList[1] = new Bow();

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

	virtual public void CharacterRotation(Vector2 target)
    {
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

		target = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

		transform.up = target;
	}

	virtual public void Death()
    {
        Debug.Log("basic isDead");
        isAlive = false;
    }

    virtual public void MovementAnimations()
    {
        Debug.Log("basic animation");
    }

    public void UseWeapon(Vector2 dir) {

        weaponList[activeWeaponIndex].Attack(dir);
        Debug.Log("basic use weapon");
    }

    virtual public void UpdateMovement(Vector2 dir)
    {
        rb.velocity = dir * speed;

        Debug.Log("Movement: " + dir);
    }

    public void UseDash(Vector2 dir)
    {
        Debug.Log("Dash");
    }
     
    public void TakeDamage(int dmg)
    {
        health -= dmg;
        Debug.Log("basic takedamage");
    }

}
